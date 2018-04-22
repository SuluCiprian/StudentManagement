using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentsManagement.Persistence.EF
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(StudentsManagementContext context)
           : base(context)
        {

        }

        public IEnumerable<Activity> GetActivities()
        {
            return StudentsManagementContext.Activities.ToList();
        }

        public IEnumerable<ActivityType> GetAvailableActivityTypes()
        {
            return StudentsManagementContext.ActivityTypes.AsEnumerable();
        }

        public IEnumerable<Student> GetStudentsByActivityId(int id)
        {
            var studentsLink = StudentsManagementContext.Activities.SingleOrDefault(a => a.Id == id).StudentsLink;
            List<Student> retStudents = new List<Student>();
            foreach (var studentLink in studentsLink)
            {
                retStudents.Add(studentLink.Student);
            }
            return retStudents;
        }

        public StudentsManagementContext StudentsManagementContext
        {
            get
            {
                return Context as StudentsManagementContext;
            }
        }

        public override IEnumerable<Activity> GetAll()
        {
            return StudentsManagementContext.Activities
                .Include(a => a.Type).AsEnumerable();
        }
    }
}
