using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentsManagementContext context)
            : base(context)
        {

        }

        public IEnumerable<Activity> GetActivitiesByTeacherId(int teachId)
        {
            var activities = StudentsManagementContext.Teachers.FirstOrDefault(a => a.Id == teachId).Activities;
            List<Activity> retActivities = new List<Activity>();
            foreach (var activity in activities)
            {
                retActivities.Add(activity);
            }

            return retActivities;
        }

        public void CreateActivityForTeacher(int teacherId, Activity activity)
        {
            var teacher = StudentsManagementContext.Teachers.Find(teacherId);
            teacher.Activities.Add(activity);
        }

        public Teacher GetTeacherWithUserName(string userName)
        {
            var teacher = StudentsManagementContext.Teachers.FirstOrDefault(s => s.UserName == userName);
            return teacher;
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
