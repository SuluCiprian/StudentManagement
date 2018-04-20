using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace StudentsManagement.Persistence.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentsManagementContext _context;

        public UnitOfWork(StudentsManagementContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
            Teachers = new TeacherRepository(_context);
            Activities = new ActivityRepository(_context);
            StudentActivityInfo = new StudentActivityInfoRepository(_context);
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
            _context.Dispose();
        }

        public void Initialize()
        {
            if (!_context.ActivityTypes.Any(at => at.Name.Equals("Course")))
                _context.ActivityTypes.Add(new Domain.ActivityType { Name = "Course" });

            if (!_context.ActivityTypes.Any(at => at.Name.Equals("Laboratory")))
                _context.ActivityTypes.Add(new Domain.ActivityType { Name = "Laboratory" });

            _context.SaveChanges();

        }
    }
}
