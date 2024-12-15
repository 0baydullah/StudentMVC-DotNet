﻿using FormSubmission.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormSubmission.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
    }
}