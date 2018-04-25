using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateStudent(Student student)
        {
            unitOfWork.Students.Insert(student);
            unitOfWork.Complete();
        }

        public void CreateTeacher(Teacher teacher)
        {
            unitOfWork.Teachers.Insert(teacher);
            unitOfWork.Complete();
        }

        public int GetStudentId(string userName)
        {
            var user = unitOfWork.Students.GetStudentWithUserName(userName);
            return user.Id;
        }

        public IEnumerable<Student> GetStudents()
        {
            IEnumerable<Student> students = unitOfWork.Students.GetStudents();
            return students;
        }

        public IEnumerable<Teacher> GetTeacher()
        {
            throw new NotImplementedException();
        }

        public int GetTeacherId(string userName)
        {
            var user = unitOfWork.Teachers.GetTeacherWithUserName(userName);
            return user.Id;
        }
    }
}
