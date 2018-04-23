using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StudentsManagement.Persistence.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private  StudentsManagementContext _context = null;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            InitializeDbContext(serviceProvider);
        }

        public IStudentRepository Students { get; set; }

        public ITeacherRepository Teachers { get; set; }

        public IActivityRepository Activities { get; set; }

        public IStudentActivityInfoRepository StudentActivityInfo { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        private void InitializeDbContext(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetService<StudentsManagementContext>();
            if (_context != null)
            { 
                Students = new StudentRepository(_context);
                Teachers = new TeacherRepository(_context);
                Activities = new ActivityRepository(_context);
                StudentActivityInfo = new StudentActivityInfoRepository(_context);
            }
        }
        
        public void InitializeData(IServiceProvider serviceProvider)
        {           

            if (!_context.ActivityTypes.Any(at => at.Name.Equals("Course")))
                _context.ActivityTypes.Add(new Domain.ActivityType { Name = "Course" });

            if (!_context.ActivityTypes.Any(at => at.Name.Equals("Laboratory")))
                _context.ActivityTypes.Add(new Domain.ActivityType { Name = "Laboratory" });

            if (!_context.Students.Any(at => at.UserName.Equals("test@test.com")))
                _context.Students.Add(new Domain.Student { UserName = "test@test.com", Name = "Test Teston Jr." });
            _context.SaveChanges();

            if (!_context.Teachers.Any(at => at.UserName.Equals("teacher@gmail.com")))
                _context.Teachers.Add(new Domain.Teacher { UserName = "teacher@gmail.com", Name = "Buffalo Smith" });
            _context.SaveChanges();

        }

        public void InitializeContext(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StudentsManagementContext>(options =>
                                     options.UseLazyLoadingProxies()
                                     .UseSqlServer(config.GetConnectionString("StudentsManagement")));

            InitializeDbContext(services.BuildServiceProvider());
        }
    }
}
