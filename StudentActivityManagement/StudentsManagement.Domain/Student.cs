﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ActivityStudent> ActivitiesLink { get; set; }
    }
}
