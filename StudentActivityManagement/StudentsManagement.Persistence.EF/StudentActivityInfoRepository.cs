using System;
using System.Collections.Generic;
using System.Text;
using StudentsManagement.Domain;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    public class StudentActivityInfoRepository : Repository<StudentActivityInfo>, IStudentActivityInfoRepository
    {
        private StudentsManagementContext StudentsManagementContext
        {
            get
            {
                return Context as StudentsManagementContext;
            }
        }

        public StudentActivityInfoRepository(StudentsManagementContext context)
            : base(context)
        {

        }

        public StudentActivityInfo GetScheduledActivityInfo(Student student, ScheduleEntry scheduleEntry)
        {
            StudentActivityInfo retVal = null;

            retVal = StudentsManagementContext.StudentActivityInfo.SingleOrDefault(s => s.StudentId == student.Id
                                                                                 && s.Occurence.Equals(scheduleEntry));

            return retVal;
        }
    }
}
