using Microsoft.EntityFrameworkCore;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    public class StudentsManagementContext : DbContext
    {
        public StudentsManagementContext(DbContextOptions<StudentsManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<StudentActivityInfo> StudentActivityInfo { get; set; }
        public virtual DbSet<ActivityStudent> ActivityStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ActivityStudent>().HasKey(a => new { a.ActivityId, a.StudentId });
        }
    }
}
