using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentActivityMenagement.Models.ActivityViewModel
{
    public class AddStudentViewModel
    {
        public IEnumerable<Student> Students { get; set; }
    }
}
