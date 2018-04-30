﻿using StudentsManagement.Domain;
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

        public void AddStudentToActivity(int activityId, Student student)
        {
            ActivityStudent activityStudent = new ActivityStudent();
            activityStudent.StudentId = student.Id;
            activityStudent.Student = student;
            activityStudent.ActivityId = activityId;

            var activity = StudentsManagementContext.Activities.Find(activityId);
            activityStudent.Activity = activity;
            
            activity.StudentsLink.Add(activityStudent);
        }

        public void AddScheduleEntryToActivity(Activity activity, ScheduleEntry entry)
        {
            activity.Schedule.Add(entry);
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
            return StudentsManagementContext.Activities.AsEnumerable();                
        }

        public void RemoveStudentFromActivity(int activityId, Student student)
        {
            var studentsLink = StudentsManagementContext.ActivityStudents.SingleOrDefault(a => a.ActivityId == activityId && a.StudentId == student.Id);
            StudentsManagementContext.ActivityStudents.Remove(studentsLink);
            StudentsManagementContext.SaveChanges();
        }

        public void RemoveScheduleEntryFromActivity(Activity activity, ScheduleEntry scheduleEntry)
        {
            activity.Schedule.Remove(scheduleEntry);
        }

        public bool IsStudentSubscribedToActivity(Activity activity, Student student)
        {
            bool retVal = true;
            var studentsLink = StudentsManagementContext.ActivityStudents.SingleOrDefault(a => a.ActivityId == activity.Id && a.StudentId == student.Id);
            
            if(studentsLink == null)
            {
                retVal = false;
            }

            return retVal;
        }

        public bool DoesActivityHaveScheduleOn(Activity activity, ScheduleEntry scheduleEntry)
        {
            bool retVal = true;

            if(!activity.Schedule.Contains(scheduleEntry))
            {
                retVal = false;
            }

            return retVal;
        }
    }
}
