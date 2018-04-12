using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
