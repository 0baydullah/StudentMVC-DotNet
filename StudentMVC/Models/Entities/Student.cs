using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMVC.Models.Entities
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [ForeignKey("AId")]
        public Address Address { get; set; }
        
        public double Cgpa { get; set; }
        public DateOnly Dob { get; set; }
    }
}
