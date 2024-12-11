using System.ComponentModel.DataAnnotations;

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
        public Address Address { get; set; }
        public int AId { get; set; }
        public double Cgpa { get; set; }
        public DateOnly Dob { get; set; }
        Gender Gender { get; set; }
    }
}
