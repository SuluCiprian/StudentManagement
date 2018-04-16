using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagament.Core.Shared
{
    public interface IAuthenticationService
    {
        void RegisterAsync();

        Task<bool> Login(string userName, string password, bool remeberUser);
        Task<bool> Register(string userName, string password);
    }
}
