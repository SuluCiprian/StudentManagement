using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
