namespace StudentMVC.Models
{
    public class StudentDetailsViewModel
    {
        public int SId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Cgpa { get; set; }
        public DateOnly Dob { get; set; }
        public int AId { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
