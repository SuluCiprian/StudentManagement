using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class ScheduleEntry
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public DateTime Occurence { get; set; }

        public bool Equals(ScheduleEntry scheduleEntry)
        {
            bool retVal = false;
            if(scheduleEntry == null)
            {
                retVal = false;
            }

            if(scheduleEntry.ActivityId == ActivityId && scheduleEntry.Occurence.Equals(Occurence))
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }

        public override bool Equals(object obj)
        {
            if(typeof(ScheduleEntry).IsAssignableFrom(obj.GetType()))
            {
                return Equals((ScheduleEntry)obj);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = -208794959;
            hashCode = hashCode * -1521134295 + ActivityId.GetHashCode();
            hashCode = hashCode * -1521134295 + Occurence.GetHashCode();
            return hashCode;
        }
    }
}
