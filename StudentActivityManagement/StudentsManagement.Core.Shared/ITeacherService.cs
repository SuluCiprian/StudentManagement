﻿using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface ITeacherService
    {
        IEnumerable<Activity> GetTeacherActivities(int teachId);
        void CreateActivityForTeacher(int teacherId, Activity activity);
        void Create(Activity activity);
        int Edit(StudentActivityInfo activityInfo);
        void Insert(StudentActivityInfo activityInfo);
        Activity GetDelete(int id);
        void PostDelete(int id);
        bool StudentExists(int id);
        IEnumerable<ActivityType> GetAvailableActivityTypes();
        void AddStudent(int activityId, Student student);
        void RemoveStudent(int activityId, Student student);
        IEnumerable<Student> GetStudentsOnActivity(int id);
        IEnumerable<StudentActivityInfo> GetActivityInfos(int activityId);
        StudentActivityInfo GetActivityInfo(int activityInfoId);
        void AddScheludleEntryForActivity(int id, ScheduleEntry entry);
        Activity getActivity(int activityId);

        void UpdateActivityPrimaryData(Activity activity);

        void UpdateSubscribedStudents(int activityId, ICollection<string> studentNames);
        void UpdateSchedule(int activityId, ICollection<ScheduleEntry> schedule);

        bool IsStudentSubscribedToActivity(int activityId, Student student);
    }
}
