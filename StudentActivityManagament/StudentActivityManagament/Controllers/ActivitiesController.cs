using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentActivityManagament.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";

            return View();
        }
    }
}