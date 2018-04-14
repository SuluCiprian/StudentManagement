using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Persistence.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentsManagamentContext _context;

        public UnitOfWork(StudentsManagamentContext context)
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
