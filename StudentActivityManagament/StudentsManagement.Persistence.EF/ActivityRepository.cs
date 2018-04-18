using StudentsManagement.Domain;
using StudentsManagement.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentsManagement.Persistence.EF
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(StudentsManagementContext context)
           : base(context)
        {

        }

        public IEnumerable<Activity> GetActivities()
        {
            return StudentsManagementContext.Activities.ToList();
        }

        public StudentsManagementContext StudentsManagementContext
        {
            get
            {
                return Context as StudentsManagementContext;
            }
        }
    }
}
