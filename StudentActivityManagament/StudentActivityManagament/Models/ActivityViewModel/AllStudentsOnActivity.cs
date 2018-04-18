using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentActivityMenagement.Models.ActivityViewModel
{
    public class AllStudentsOnActivity
    {
        public List<int> Id { get; set; }

        public List<string> Name { get; set; }

        public string ActivityName { get; set; }
    }
}
