using FluentNHibernate.Mapping;
using NHibernateDemoApp.Data.Entity;

namespace NHibernateDemoApp.Data.Mapping
{
    public class AcademicClassMap : ClassMap<AcademicClass>
    {
        public AcademicClassMap()
        {
            Table("AcademicClass");
            Id(x => x.Id);
            Map(x => x.Name);

            HasManyToMany(x => x.Students)
                .Table("StudentClass")
                .ChildKeyColumn("StudentId")
                .ParentKeyColumn("ClassId");
        }
    }
}
