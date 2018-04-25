using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsManagement.Persistence
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        IEnumerable<Activity> GetActivitiesByTeacherId(int teachId);
        void CreateActivityForTeacher(int teacherId, Activity activity);
        Teacher GetTeacherWithUserName(string userName);
    }
}
