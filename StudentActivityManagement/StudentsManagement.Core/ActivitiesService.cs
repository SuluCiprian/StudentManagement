﻿using StudentsManagement.Core.Shared;
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

        public void Edit(StudentActivityInfo activityInfo)
        {
            var currentActivity =  _unitOfWork.StudentActivityInfo.GetById(activityInfo.Id);            
            currentActivity.Attendance = activityInfo.Attendance;
            currentActivity.Grade = activityInfo.Grade;
            _unitOfWork.Complete();
        }

        public IEnumerable<StudentActivityInfo> GetActivityInfos(int activityId)
        {
            return _unitOfWork.StudentActivityInfo.SearchFor(a => a.ActivityId == activityId);
        }

        public IEnumerable<ScheduleEntry> GetScheduleEntries(int id)
        {
            return _unitOfWork.Activities.GetById(id).Schedule.AsEnumerable();
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

        public void CreateScheduleEntry(ScheduleEntry scheduleEntry)
        {
            throw new NotImplementedException();
        }

        public void AddStudent(int activityId, Student student)
        {
            _unitOfWork.Activities.AddStudentToActivity(activityId, student);
        }

        public StudentActivityInfo GetActivityInfo(int activityInfoId)
        {
            return _unitOfWork.StudentActivityInfo.GetById(activityInfoId);
        }
    }
}