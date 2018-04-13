using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Core.Shared
{
    public interface IInitializer
    {
        void Initialize(IServiceCollection service);
        void Configure(IApplicationBuilder app);
    }
}
