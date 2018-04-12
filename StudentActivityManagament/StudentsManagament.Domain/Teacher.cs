using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
