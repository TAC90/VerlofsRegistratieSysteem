using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace VerlofsRegistratieSysteem.Models
{
    public class AbsenceContext : DbContext
    {
        public AbsenceContext() : base("DefaultConnection")
        {

        }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<RoleViewModel> RoleViewModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}