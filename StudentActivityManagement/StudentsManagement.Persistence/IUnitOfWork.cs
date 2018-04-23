using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IActivityRepository Activities { get; }
        IStudentActivityInfoRepository StudentActivityInfo { get; }
        int Complete();
        void InitializeContext(IServiceCollection services, IConfiguration config);
        void InitializeData(IServiceProvider serviceProvider);
    }
}
