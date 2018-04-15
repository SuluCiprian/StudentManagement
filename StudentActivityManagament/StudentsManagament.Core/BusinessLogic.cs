using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudentsManagament.Core.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagament.Core
{
    class BusinessLogic: IBusinessLogic
    {
        IAuthenticationService service;
        List<IInitializer> initList;
        AccountLogic account;

        public BusinessLogic()
        {
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

        public void Initialize(IServiceCollection serviceCollection)
        {
            foreach (var item in initList)
            {
               // item.Initialize(serviceCollection);
            }
        }
    }
}
