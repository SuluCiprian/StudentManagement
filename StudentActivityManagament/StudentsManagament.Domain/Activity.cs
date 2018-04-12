using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ActivityType Type { get; set; }
        public string Description { get; set; }
        public Teacher Owner { get; set; }
    }
}
