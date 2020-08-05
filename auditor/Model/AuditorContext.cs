using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auditor.Model
{
    class AuditorContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Arm> Arms { get; set; }
        public DbSet<Programm> Programms { get; set; }
        public DbSet<TechType> TechTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SziType> SziTypes { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Szi> Szis { get; set; }
        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=auditor; Trusted_Connection=True");
        }



    }
}
