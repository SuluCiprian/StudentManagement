using Microsoft.AspNetCore.Mvc.Rendering;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentActivityMenagement.Models.ActivityViewModel
{
    public class ActivityViewModel
    {
        private IEnumerable<ActivityType> activityTypes;

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Selected Type")]
        public int SelectedTypeId { get; set; }

        public ActivityType SelectedType
        {
            get
            {
                ActivityType retVal = null;
                if (activityTypes != null)
                {
                    retVal = ActivityTypes.Where(at => at.Id == SelectedTypeId).FirstOrDefault();
                }

                return retVal;
                
            }
        }

        public ICollection<ScheduleEntry> Schedule { get; set; }

        public ICollection<ActivityStudent> StudentsLink { get; set; }

        public IEnumerable<ActivityType> ActivityTypes
        {
            get
            {
                return activityTypes;
            }
            set
            {
                activityTypes = value;
                ActivityTypesList = activityTypes.Select(at => new SelectListItem() { Value = "" + at.Id, Text = at.Name }).ToList();
            }
        }

        public IEnumerable<SelectListItem> ActivityTypesList
        {
            get;
            private set;
        }

        public List<DateTime> Occurences { get; set; }

        public List<int> StudentIds { get; set; }
        public List<Student> Students { get; set; }
    }
}
