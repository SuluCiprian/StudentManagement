﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Core.Shared
{
    public interface IBusinessLogic : IInitializer
    {
        IAuthenticationService GetAuthenticationService();
        IStudentService GetStudentService();
    }
}