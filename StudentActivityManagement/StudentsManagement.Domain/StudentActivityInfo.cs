using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class StudentActivityInfo
    {
        public int ActivityId { get; set; }
        public int StudentId { get; set; }
        public List<int> Grade { get; set; }
        public List<int> AttendanceNumber { get; set; }
        public List<DateTime> Date { get; set; }
    }
}
