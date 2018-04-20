using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class ActivityStudent
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
