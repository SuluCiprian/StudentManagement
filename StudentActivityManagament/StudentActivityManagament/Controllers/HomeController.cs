using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentActivityManagament.Models;
using StudentsManagament.Core.Shared;

namespace StudentActivityManagament.Controllers
{
    
    public class HomeController : Controller
    {
        private IAuthenticationService authenticationService;

        public HomeController(IAuthenticationService service)
        {
            authenticationService = service;
        }

        public IActionResult Index()
        {
            IActionResult result = RedirectToAction("Login", "Account");

            if (authenticationService.IsUserSignedIn())
            {
                result = View();
            }
            return result;
        }
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
