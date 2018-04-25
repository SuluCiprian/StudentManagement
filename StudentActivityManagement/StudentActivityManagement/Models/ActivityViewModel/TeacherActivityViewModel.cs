using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentActivityMenagement.Models.ActivityViewModel
{
    public class TeacherActivityViewModel
    {
        public IEnumerable<Student> StudentsOnActivity { get; set; }

        public IEnumerable<StudentActivityInfo> ActivityInfos { get; set; }

        public IEnumerable<ScheduleEntry> ScheduleEntries { get; set; }
    }
}
