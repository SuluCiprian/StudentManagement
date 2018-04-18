using Microsoft.AspNetCore.Identity;
using StudentActivityMenagement.Data;
using StudentsManagement.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsManagement.Authentication
{
    public class AuthenticationInitializeService : IAuthenticationInitializeService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthenticationInitializeService(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async void Initialize()
        {
            //create database schema if none exists
            context.Database.EnsureCreated();

            //Create the Administartor Role
            if (!context.Roles.Any(r => r.Name == "Teacher"))
            { 
                await roleManager.CreateAsync(new IdentityRole("Teacher"));
            }

            if (!context.Roles.Any(r => r.Name == "Student"))
            { 
                await roleManager.CreateAsync(new IdentityRole("Student"));
            }

            //Create the default Admin account and apply the Administrator role
            string user = "teacher@gmail.com";
            string password = "T3@ch3r";

            if (!context.Users.Any(usr => usr.UserName.Equals(user)))
            {            
                ApplicationUser appUser = new ApplicationUser { UserName = user, Email= user, EmailConfirmed = true};
                var result = await userManager.CreateAsync(appUser, password);
                if (result.Succeeded)
                {                
                    await userManager.AddToRoleAsync(appUser, "Teacher");
                }
            }

        }
    }
}
