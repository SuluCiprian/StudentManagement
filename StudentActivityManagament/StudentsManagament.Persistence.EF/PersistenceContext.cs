using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Persistence.EF
{
    public class PersistenceContext : IPersistContext
    {
        public void Configure(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }

        public IActivityRepository GetActivityRepository()
        {
            throw new NotImplementedException();
        }

        public IStudentRepository GetStudentRepository()
        {
            throw new NotImplementedException();
        }

        public ITeacherRepository GetTeacherRepository()
        {
            throw new NotImplementedException();
        }

        public void Initialize(IServiceCollection service)
        {
            throw new NotImplementedException();
        }

    }
}
