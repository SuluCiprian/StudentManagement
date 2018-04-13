using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IPersistContext
    {
        void Initialize(IServiceCollection service);
        void Configure(IApplicationBuilder app);
        IActivityRepository GetActivityRepository();
        IStudentRepository GetStudentRepository();
        ITeacherRepository GetTeacherRepository();
    }
}
