using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentActivityMenagement.Models.ActivityViewModel
{
    public class Activities
    {
        public List<int> IdActivities { get; set; }

        public List<string> ActivitiesName { get; set; }

        public List<string> ActivitiesType { get; set; }

        public List<string> ActivitiesDescription { get; set; }

        public string StatusMessage { get; set; }
    }
}
