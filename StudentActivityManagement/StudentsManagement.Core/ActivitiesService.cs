using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Core
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivitiesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Activity activity)
        {
            _unitOfWork.Activities.Insert(activity);
            _unitOfWork.Complete();
        }

        public IEnumerable<StudentActivityInfo> Details(int id)
        {
            var activity = _unitOfWork.StudentActivityInfo.SearchFor(a => a.ActivityId == id).ToList();
            return activity;
        }

        public void Edit(int id, StudentActivityInfo activityInfo)
        {
            _unitOfWork.StudentActivityInfo.Insert(activityInfo);
            _unitOfWork.Complete();
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

        public void CreateActivityForTeacher(int teacherId, Activity activity)
        {
            _unitOfWork.Teachers.CreateActivityForTeacher(teacherId, activity);
            _unitOfWork.Complete();
        }

        public Activity GetDelete(int id)
        {
            var activity = _unitOfWork.Activities.GetById(id);
            return activity;
        }

        public IEnumerable<Activity> Index()
        {
            var activities = _unitOfWork.Activities.GetAll();            
            return activities;
        }

        public IEnumerable<Activity> GetStudentActivities(int studId)
        {
            var activities = _unitOfWork.Students.GetActivitiesByStudentId(studId);
            return activities;
        }

        public IEnumerable<Activity> GetTeacherActivities(int teachId)
        {
            var activities = _unitOfWork.Teachers.GetActivitiesByTeacherId(teachId);
            return activities;
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
    }
}
