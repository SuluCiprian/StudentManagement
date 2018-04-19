using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentsManagementContext context)
            :base(context)
        {
             
        }

        public IEnumerable<Student> GetStudentsByActivityId(int id)
        {
            //return StudentsManagementContext.Activities.SingleOrDefault(a => a.Id == id).Students.ToList();
            return null;
        }

        public StudentsManagementContext StudentsManagementContext
        {
            get
            {
                return Context as StudentsManagementContext;
            }
        }
    }
}
