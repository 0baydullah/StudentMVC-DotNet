using Microsoft.EntityFrameworkCore;
using StudentMVC.Models.Entities;

namespace StudentMVC.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
    }
}
