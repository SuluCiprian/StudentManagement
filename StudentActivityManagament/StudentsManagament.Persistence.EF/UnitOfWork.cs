using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public IStudentRepository Students { get; set; }

        public ITeacherRepository Teachers { get; set; }

        public IActivityRepository Activities { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
