using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Persistence;

namespace StudentActivityManagament.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public ActivitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";

            _unitOfwork.Activities.Insert(new StudentsManagament.Domain.Activity
            {
                Name = "curs"
            });

            _unitOfwork.Activities.Insert(new StudentsManagament.Domain.Activity
            {
                Name = "seminar"
            });

            _unitOfwork.Complete();

            var activities = _unitOfwork.Activities.GetAll();

            return View(activities);
        }
    }
}