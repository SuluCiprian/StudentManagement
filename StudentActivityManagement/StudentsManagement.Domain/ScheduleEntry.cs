using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class ScheduleEntry
    {
        public int Id { get; set; }
        public Activity Activity { get; set; }
        public DateTime Occurence { get; set; }
    }
}
