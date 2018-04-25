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

        IEnumerable<Student> GetStudents();
    }
}
