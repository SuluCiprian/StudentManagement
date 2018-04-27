using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentActivityMenagement.Models.ActivityViewModel;
using StudentsManagement.Core.Shared;

namespace StudentActivityMenagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IActivitiesService _activitiesService;
        private readonly IStudentsService _studentsService;
        private readonly IAuthenticationService _authenticationService;

        public StudentController(IActivitiesService activitiesService, IStudentsService studentsService, IAuthenticationService authenticationService)
        {
            _activitiesService = activitiesService;
            _studentsService = studentsService;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";
            var id = _authenticationService.GetUserId();

            var activities = _studentsService.GetStudentActivities(id);
            return View(activities);
        }

        // GET: Activity/Details/5
        public IActionResult Details(int id)
        {
            var activity = _activitiesService.Details(id);
            if (activity == null)
            {
                return NotFound();
            }
            var activityInfos = _activitiesService.Details(id);
            var scheduleEntries = _activitiesService.GetScheduleEntries(id);

            var studentActivity = new StudentActivityViewModel();
            studentActivity.ActivityInfos = activityInfos;
            studentActivity.Schedules = scheduleEntries;
            //studentActivity.Type = activity.ToList()[1].Occurance.Activity.Type.Name;
            return View("StudentActivity", studentActivity);

        }
    }
}