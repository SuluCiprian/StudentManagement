using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentActivityMenagement.Models.ActivityViewModel
{
    public class StudentViewModel
    {
        [Required]
        public string Name { get; set; }

        public string UserName { get; set; }
    }
}
