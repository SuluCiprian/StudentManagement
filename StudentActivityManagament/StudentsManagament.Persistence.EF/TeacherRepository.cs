using StudentsManagament.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Persistence.EF
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentsManagamentContext context)
            : base(context)
        {

        }
    }
}
