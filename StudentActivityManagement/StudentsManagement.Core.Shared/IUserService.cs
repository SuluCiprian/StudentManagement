using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface IUserService
    {
        void CreateStudent(Student student);
        void CreateTeacher(Teacher teacher);
        int GetTeacherId(string userName);
        int GetStudentId(string userName);

        IEnumerable<Student> GetStudents();
        IEnumerable<Teacher> GetTeacher();
    }
}
