using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace StudentsManagement.Authentication
{
    public class AuthenticationService : Core.Shared.IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;
        private readonly IBusinessLogic businessLogic;
        private readonly IUserService userService;

        public AuthenticationService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            IBusinessLogic businessLogic,
            ILogger<AuthenticationService> logger,
            IUserService userService)
        {
            this.businessLogic = businessLogic;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.logger = logger;
            this.userService = userService;
        }

        public bool IsUserSignedIn()
        {
            bool retVal = false;
            if (signInManager.IsSignedIn(signInManager.Context.User))
            {                
                retVal = true;
            }
            return retVal;
        }

        public string GetUserName()
        {
            return signInManager.UserManager.GetUserName(signInManager.Context.User);
        }

        public async Task<bool> Login(string userName, string password, bool remeberUser)
        {
            bool retVal = false;
            var result = await signInManager.PasswordSignInAsync(userName, password, remeberUser, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                logger.LogInformation("User logged in.");
                retVal = true;
            }

            return retVal;
        }

        public async Task<bool> Register(string userName, string password, string fullName, bool isStudent)
        {
            bool retVal = false;
            var user = new ApplicationUser { UserName = userName, Email = userName };
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                logger.LogInformation("User created a new account with password.");
                if (isStudent)
                {
                    await userManager.AddToRoleAsync(user, "Student");
                    Student student = new Student { UserName = userName, Name = fullName };
                    userService.CreateStudent(student);


                }
                else
                {
                    await userManager.AddToRoleAsync(user, "Teacher");
                    Teacher teacher = new Teacher { UserName = userName, Name = fullName };
                    userService.CreateTeacher(teacher);

                }
                retVal = true;
            }
            return retVal;
        }

        public async Task<bool> Logout()
        {
            bool retVal = true;
            await signInManager.SignOutAsync();

            return retVal;
        }

        public bool IsUserStudent()
        {
            bool isStudent = signInManager.Context.User.IsInRole("Student");

            return isStudent;
        }
    }
}
