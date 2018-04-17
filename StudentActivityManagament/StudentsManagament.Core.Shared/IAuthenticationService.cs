using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagament.Core.Shared
{
    public interface IAuthenticationService
    {
        bool IsUserSignedIn();

        string GetUserName();

        Task<bool> Login(string userName, string password, bool remeberUser);
        Task<bool> Register(string userName, string password);
        Task<bool> Logout();
    }
}
