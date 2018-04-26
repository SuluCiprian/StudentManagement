using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudentsManagement.Domain;

namespace StudentActivityMenagement.Models.ActivityViewModel
{
    public class StudentActivityViewModel
    {
        public int ActivityId { get; set; }

        public IEnumerable<StudentActivityInfo> ActivityInfos { get; set; }

        public IEnumerable<ScheduleEntry> Schedules { get; set; }

        public string Type { get; set; }
    }
}
