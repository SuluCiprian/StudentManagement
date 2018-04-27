using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class StudentActivityInfo
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public int Attendance { get; set; }
        public int OccurenceId { get; set; }
        public virtual ScheduleEntry Occurence { get; set; }
    }
}
