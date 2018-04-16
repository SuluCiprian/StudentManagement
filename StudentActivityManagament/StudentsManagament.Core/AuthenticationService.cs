//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using StudentActivityManagament.Models;
//using StudentActivityManagament.Models.AccountViewModels;
//using StudentActivityManagament.Services;
//using StudentsManagament.Core.Shared;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace StudentsManagament.Core
//{
//    class AuthenticationService : IAuthenticationService
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly ILogger _logger;
//        private readonly IEmailSender _emailSender;
//        private readonly SignInManager<ApplicationUser> _signInManager;

//        public AuthenticationService(
//            UserManager<ApplicationUser> userManager,
//            IEmailSender emailSender,
//            IBusinessLogic businessLogic,
//            SignInManager<ApplicationUser> signInManager,
//            ILogger<AuthenticationService> logger)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _emailSender = emailSender;
//            _logger = logger;
//        }

//        public async Task RegisterAsync(RegisterViewModel model, string returnUrl = null)
//        {
//            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
//            var result = await _userManager.CreateAsync(user, model.Password);
//            if (result.Succeeded)
//            {
//                _logger.LogInformation("User created a new account with password.");

//                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
//                await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

//                await _signInManager.SignInAsync(user, isPersistent: false);
//                _logger.LogInformation("User created a new account with password.");
//            }
//    }
//}
