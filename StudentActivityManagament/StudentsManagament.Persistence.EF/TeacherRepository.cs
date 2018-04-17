using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence.EF
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentsManagementContext context)
            : base(context)
        {

        }
    }
}
