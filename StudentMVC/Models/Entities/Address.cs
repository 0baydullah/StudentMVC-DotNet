using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMVC.Models.Entities
{
    public class Address
    {
        [Key]
        public int AId { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
