using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core
{
    public class StudentsService: IStudentsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var allStudents = _unitOfWork.Students.GetAll();
            return allStudents;
        }

        public void AddStudentToActivity(int activityId, Student student)
        {
            _unitOfWork.Activities.AddStudentToActivity(activityId, student);
        }
    }
}
