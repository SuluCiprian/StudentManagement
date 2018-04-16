using StudentsManagament.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentsManagament.Persistence.EF
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(StudentsManagamentContext context)
           : base(context)
        {

        }

        public StudentsManagamentContext StudentsManagamentContext
        {
            get
            {
                return Context as StudentsManagamentContext;
            }
        }
    }
}
