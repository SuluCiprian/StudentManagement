using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAllStudents();
        void AddStudentToActivity(int activityId, Student student);
    }
}
