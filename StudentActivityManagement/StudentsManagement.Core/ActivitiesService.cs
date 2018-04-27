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

        public IEnumerable<ScheduleEntry> GetScheduleEntries(int id)
        {
            return _unitOfWork.Activities.GetById(id).Schedule.AsEnumerable();
        }

        public IEnumerable<StudentActivityInfo> Details(int id)
        {
            var activity = _unitOfWork.StudentActivityInfo.SearchFor(a => a.ActivityId == id).ToList();
            return activity;
        }

       
    }
}