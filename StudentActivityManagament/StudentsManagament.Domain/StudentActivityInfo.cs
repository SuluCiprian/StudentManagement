using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Domain
{
    class StudentActivityInfo
    {
        public int ActivityId { get; set; }
        public int Mark { get; set; }
        public int StudentId { get; set; }
        public bool Presence { get; set; }
        public DateTime Date { get; set; }
    }
}
