using JobApplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplication.Data
{
    public class DataContext:DbContext
    {
        public DbSet<DeveloperJob> DeveloperJobs { get; set; }
        public DbSet<CompanyAddress> companyAddress { get; set; }
        public DbSet<CompanyType> companyType { get; set; }
        public DbSet<Industry> industry { get; set; }
        public DbSet<JobType> jobType { get; set; }

        public DataContext(DbContextOptions<DataContext>options)
            :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
