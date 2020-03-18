using FluentNHibernate.Mapping;
using NHibernateDemoApp.Data.Entity;

namespace NHibernateDemoApp.Data.Mapping
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Student");
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}
