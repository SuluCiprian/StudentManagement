using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface IActivitiesService
    {
        IEnumerable<Activity> Index();
        IEnumerable<StudentActivityInfo> Details(int id);
        void Create(Activity activity);
        void Edit(StudentActivityInfo activityInfo);
        void Insert(StudentActivityInfo activityInfo);
        Activity GetDelete(int id);
        void PostDelete(int id);
        bool StudentExists(int id);
        IEnumerable<ActivityType> GetAvailableActivityTypes();
        void AddStudent(int activityId, Student student);
        IEnumerable<Student> GetStudentsOnActivity(int id);
        IEnumerable<StudentActivityInfo> GetActivityInfos(int activityId);
        StudentActivityInfo GetActivityInfo(int activityInfoId);

        IEnumerable<Activity> GetStudentActivities(int studId);
        IEnumerable<Activity> GetTeacherActivities(int teachId);
        void CreateActivityForTeacher(int teacherId, Activity activity);
        IEnumerable<ScheduleEntry> GetScheduleEntries(int id);
        void AddScheludleEntryForActivity(int id, ScheduleEntry entry);
    }
}
