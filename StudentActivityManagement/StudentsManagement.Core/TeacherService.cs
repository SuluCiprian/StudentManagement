using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentsManagement.Core
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateActivityForTeacher(int teacherId, Activity activity)
        {
            _unitOfWork.Teachers.CreateActivityForTeacher(teacherId, activity);
            _unitOfWork.Complete();
        }

        public IEnumerable<Activity> GetTeacherActivities(int teachId)
        {
            var activities = _unitOfWork.Teachers.GetActivitiesByTeacherId(teachId);
            return activities;
        }

        public void Create(Activity activity)
        {
            _unitOfWork.Activities.Insert(activity);
            _unitOfWork.Complete();
        }

        public int Edit(StudentActivityInfo activityInfo)
        {
            var currentActivity = _unitOfWork.StudentActivityInfo.GetById(activityInfo.Id);
            currentActivity.Attendance = activityInfo.Attendance;
            currentActivity.Grade = activityInfo.Grade;
            _unitOfWork.Complete();
            return currentActivity.ActivityId;
        }

        public IEnumerable<StudentActivityInfo> GetActivityInfos(int activityId)
        {
            return _unitOfWork.StudentActivityInfo.SearchFor(a => a.ActivityId == activityId);
        }

        public IEnumerable<Student> GetStudentsOnActivity(int id)
        {
            var studentsWithId = _unitOfWork.Activities.GetStudentsByActivityId(id);
            return studentsWithId;
        }

        public IEnumerable<ActivityType> GetAvailableActivityTypes()
        {
            return _unitOfWork.Activities.GetAvailableActivityTypes().ToList();
        }

        public void AddScheludleEntryForActivity(int id, ScheduleEntry entry)
        {
            var activity = _unitOfWork.Activities.GetById(id);
            _unitOfWork.Activities.AddScheduleEntryToActivity(activity, entry);
            _unitOfWork.Complete();
        }

        public Activity GetDelete(int id)
        {
            var activity = _unitOfWork.Activities.GetById(id);
            return activity;
        }

        public void PostDelete(int id)
        {
            var activity = _unitOfWork.Activities.GetById(id);
            _unitOfWork.Activities.Delete(activity);
            _unitOfWork.Complete();
        }

        public bool StudentExists(int id)
        {
            return _unitOfWork.Students.GetById(id) != null ? true : false;
        }

        public void AddStudent(int activityId, Student student)
        {
            _unitOfWork.Activities.AddStudentToActivity(activityId, student);
        }

        public StudentActivityInfo GetActivityInfo(int activityInfoId)
        {
            return _unitOfWork.StudentActivityInfo.GetById(activityInfoId);
        }

        public void Insert(StudentActivityInfo activityInfo)
        {
            _unitOfWork.StudentActivityInfo.Insert(activityInfo);
            _unitOfWork.Complete();
        }

        public Activity getActivity(int activityId)
        {
            Activity act = _unitOfWork.Activities.GetById(activityId);
            return act;
        }
    }
}
