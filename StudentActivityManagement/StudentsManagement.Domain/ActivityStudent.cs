using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class ActivityStudent
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
