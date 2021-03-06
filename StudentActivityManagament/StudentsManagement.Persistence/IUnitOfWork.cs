﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IActivityRepository Activities { get; }
        int Complete();
    }
}
