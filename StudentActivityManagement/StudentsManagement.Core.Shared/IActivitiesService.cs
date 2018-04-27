using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface IActivitiesService
    {
        IEnumerable<StudentActivityInfo> Details(int id);
        IEnumerable<ScheduleEntry> GetScheduleEntries(int id);       
    }
}
