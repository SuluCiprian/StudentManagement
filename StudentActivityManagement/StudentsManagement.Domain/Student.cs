using System;
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

        public bool Equals(Student student)
        {
            bool retVal = false;
            if (student == null)
            {
                retVal = false;
            }

            if (student.UserName.Equals(UserName))
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }

        public override bool Equals(object obj)
        {
            if (typeof(Student).IsAssignableFrom(obj.GetType()))
            {
                return Equals((Student)obj);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return 404878561 + EqualityComparer<string>.Default.GetHashCode(UserName);
        }
    }
}