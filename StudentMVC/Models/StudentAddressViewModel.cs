using StudentMVC.Models.Entities;

namespace StudentMVC.Models
{
    public class StudentAddressViewModel
    {
        public List<Student> Students { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
