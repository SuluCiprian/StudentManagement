using StudentsManagament.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;

namespace StudentsManagament.Persistence.EF
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
       
    }
}
