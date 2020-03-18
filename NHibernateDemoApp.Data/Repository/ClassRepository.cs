using NHibernate;
using NHibernateDemoApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NHibernateDemoApp.Data.Repository
{
    public class ClassRepository
    {
        private readonly ISession session;

        public ClassRepository()
        {
            session = NHibernateHelper.OpenSession();
        }

        public AcademicClass Get(int id)
        {
            session.Flush();
            session.Clear();

            AcademicClass entity = session.Get<AcademicClass>(id);
            return entity;
        }

        public AcademicClass First(Expression<Func<AcademicClass, bool>> predicate, bool readOnly = false)
        {
            session.Flush();
            session.Clear();
           
            var query = session.QueryOver<AcademicClass>();
            query.Where(predicate);

            return query.List<AcademicClass>().FirstOrDefault();
        }

        public IList<AcademicClass> All(bool readOnly = false)
        {
            return All(null, readOnly);
        }

        public IList<AcademicClass> All(Expression<Func<AcademicClass, bool>> predicate, bool readOnly = false)
        {
            session.Flush();
            session.Clear();

            var query = session.QueryOver<AcademicClass>();
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

        public void Save(AcademicClass entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(AcademicClass entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }

        public void Delete(int id)
        {
            AcademicClass entity = Get(id);
            if (entity == null)
            {
                throw new ArgumentException();
            }
            Delete(entity);
        }

        public void Delete(AcademicClass entity)
        {
            session.Delete(entity);
            session.Flush();
        }

    }
}
