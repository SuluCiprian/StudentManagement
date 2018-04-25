using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Activity> GetActivitiesByStudentId(int studId);
        Student GetStudentWithUserName(string userName);
        Student GetStudentWithName(string name);

        ICollection<Student> GetStudentsWithName(ICollection<string> names);
        ICollection<Student> GetStudentsWithUserName(ICollection<string> userNames);

        IEnumerable<Student> GetStudents();
    }
}
