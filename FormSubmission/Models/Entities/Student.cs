using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone must be a 11-digit number")]
        public string Phone { get; set; }
        public Major Major { get; set; }
        public Double Cgpa { get; set; }
    }
}
