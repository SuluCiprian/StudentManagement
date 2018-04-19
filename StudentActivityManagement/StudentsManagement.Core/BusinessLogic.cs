﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StudentsManagement.Core.Shared;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core
{
    public class BusinessLogic: IBusinessLogic
    {
        IAuthenticationService service;
        List<IInitializer> initList;
        AccountLogic account;
        private IUnitOfWork unitOfWork;

        public BusinessLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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