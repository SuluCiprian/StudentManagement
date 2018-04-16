using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudentsManagament.Core.Shared;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Core
{
    public class BusinessLogic: IBusinessLogic
    {
        IAuthenticationService service;
        List<IInitializer> initList;
        AccountLogic account;
        private IPersistContext persistContext;

        public BusinessLogic(IPersistContext persistContext)
        {
            this.persistContext = persistContext;
            account = new AccountLogic();
            //service.Add(account);
        }

        public void Configure(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }

        public Shared.IAuthenticationService GetAuthenticationService()
        {
            return service;
        }

        public IStudentService GetStudentService()
        {
            throw new NotImplementedException();
        }

        public void Initialize(IServiceCollection serviceCollection)
        {
            foreach (var item in initList)
            {
                item.Initialize(serviceCollection);
            }
        }
    }
}
