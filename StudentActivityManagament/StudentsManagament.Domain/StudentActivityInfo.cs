using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Domain
{
    public class StudentActivityInfo
    {
        public int ActivityId { get; set; }
        public int Mark { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public int AttendanceNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
