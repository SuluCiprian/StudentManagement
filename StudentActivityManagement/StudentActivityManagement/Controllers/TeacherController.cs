using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Core.Shared;

namespace StudentActivityMenagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IActivitiesService _activitiesService;
        private readonly IStudentsService _studentsService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService userService;

        public TeacherController(IActivitiesService activitiesService, IStudentsService studentsService, IAuthenticationService authenticationService, IUserService userService)
        {
            _activitiesService = activitiesService;
            _studentsService = studentsService;
            _authenticationService = authenticationService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var id = _authenticationService.GetUserId();
            var activities = _activitiesService.GetTeacherActivities(id);
            return View(activities);
        }
    }
}