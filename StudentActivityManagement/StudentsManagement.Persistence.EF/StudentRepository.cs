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

        

        public IEnumerable<Activity> GetActivitiesByStudentId(int studId)
        {
            var activityLinks = StudentsManagementContext.Students.FirstOrDefault(a => a.Id == studId).ActivitiesLink;
            List<Activity> retActivities = new List<Activity>();
            foreach (var activityLink in activityLinks)
            {
                retActivities.Add(activityLink.Activity);
            }

            return retActivities;
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentsManagementContext.Students.ToList();
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
