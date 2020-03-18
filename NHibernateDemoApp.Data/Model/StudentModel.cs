using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NHibernateDemoApp.Data.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string LastName { get; set; }
    }
}
