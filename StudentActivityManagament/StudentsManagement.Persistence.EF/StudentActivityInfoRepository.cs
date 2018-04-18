using System;
using System.Collections.Generic;
using System.Text;
using StudentsManagement.Domain;

namespace StudentsManagement.Persistence.EF
{
    public class StudentActivityInfoRepository: Repository<StudentActivityInfo>, IStudentActivityInfoRepository
    {
        public StudentActivityInfoRepository(StudentsManagementContext context)
            : base(context)
        {

        }
    }
}
