using NHibernate;
using NHibernateDemoApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NHibernateDemoApp.Data.Repository
{
    public class StudentRepository
    {
        private readonly ISession session;

        public StudentRepository()
        {
            session = NHibernateHelper.OpenSession();
        }

        public Student Get(int id)
        {
            session.Flush();
            session.Clear();
           
            Student entity = session.Get<Student>(id);
            return entity;
        }

        public Student First(Expression<Func<Student, bool>> predicate, bool readOnly = false)
        {
            session.Flush();
            session.Clear();
           
            IQueryOver<Student, Student> query = session.QueryOver<Student>();
            query.Where(predicate);

            return query.List<Student>().FirstOrDefault();
        }

        public IList<Student> All(bool readOnly = false)
        {
            return All(null, readOnly);
        }

        public IList<Student> All(Expression<Func<Student, bool>> predicate, bool readOnly = false)
        {
            session.Flush();
            session.Clear();

            IQueryOver<Student, Student> query = session.QueryOver<Student>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (readOnly)
            {
                return query.ReadOnly().List();
            }
            return query.List();
        }

        public void Save(Student entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(Student entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }

        public void Delete(int id)
        {
            Student entity = Get(id);
            if (entity == null)
            {
                throw new ArgumentException();
            }
            Delete(entity);
        }

        public void Delete(Student entity)
        {
            session.Delete(entity);
            session.Flush();
        }

    }
}
