using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IActivityRepository : IRepository<Activity>
    {
        IEnumerable<ActivityType> GetAvailableActivityTypes();
        IEnumerable<Student> GetStudentsByActivityId(int id);
        void AddStudentToActivity(int activityId, Student student);

        IEnumerable<Activity> GetActivities();
        void AddScheduleEntryToActivity(Activity activity, ScheduleEntry entry);
    }
}
