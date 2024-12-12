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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithMany() // Assuming Address does not reference Student
                .HasForeignKey(s => s.AId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Configure cascade delete
        }


    }
}
