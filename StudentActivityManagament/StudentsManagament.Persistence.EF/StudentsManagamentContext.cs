using Microsoft.EntityFrameworkCore;
using StudentsManagament.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Persistence.EF
{
    public class StudentsManagamentContext: DbContext
    {
        public StudentsManagamentContext(DbContextOptions<StudentsManagamentContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
