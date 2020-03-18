using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp.Data.Entity
{
    public class AcademicClass
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Student> Students { get; set; }

    }
}
