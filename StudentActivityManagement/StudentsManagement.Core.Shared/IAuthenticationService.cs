using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagement.Core.Shared
{
    public interface IAuthenticationService
    {
        bool IsUserSignedIn();
        bool IsUserStudent();
        string GetUserName();
        int GetUserId();

        Task<bool> Login(string userName, string password, bool remeberUser);
        Task<bool> Register(string userName, string password, string fullName, bool isStudent);
        Task<bool> Logout();
    }
}
