using StudentsManagament.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsManagament.Persistence.EF
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentsManagamentContext context)
            :base(context)
        {
             
        }

        public IEnumerable<Student> GetStudentsByActivityId(int id)
        {
            //return StudentsManagamentContext.Activities.SingleOrDefault(a => a.Id == id).Students.ToList();
            return null;
        }

        public StudentsManagamentContext StudentsManagamentContext
        {
            get
            {
                return Context as StudentsManagamentContext;
            }
        }
    }
}
