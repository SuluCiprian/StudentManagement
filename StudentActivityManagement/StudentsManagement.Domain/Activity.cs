using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ActivityType Type { get; set; }
        public string Description { get; set; }
        public virtual Teacher Owner { get; set; }
        public virtual ICollection<ScheduleEntry> Schedule { get; set; }
        public virtual ICollection<ActivityStudent> StudentsLink { get; set; }
    }
}
