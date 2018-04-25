using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentActivityMenagement.Models.ActivityViewModel;
using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using StudentsManagement.Persistence;

namespace StudentActivityMenagement.Controllers
{
    [Authorize]
    public class ActivitiesController : Controller
    {
        private readonly IActivitiesService _activitiesService;
        private readonly IStudentsService _studentsService;
        private readonly IAuthenticationService _authenticationService;

        public ActivitiesController(IActivitiesService activitiesService, IStudentsService studentsService, IAuthenticationService authenticationService)
        {
            _activitiesService = activitiesService;
            _studentsService = studentsService;
            _authenticationService = authenticationService;
        }


        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";
            var id = _authenticationService.GetUserId();

            if (_authenticationService.IsUserStudent())
            {                
                var activities = _activitiesService.GetStudentActivities(id);
                return View(activities);
            } else
            {
                var activities = _activitiesService.GetTeacherActivities(id);
                return View(activities);
            }

            //var activities = _activitiesService.Index();
            //return View(activities);
        }

        // GET: Activity/Details/5
        public IActionResult Details(int id)
        {
            var activity = _activitiesService.Details(id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activity/Info/5
        public IActionResult Info(int id)
        {

            TeacherActivityViewModel teacherActivity = new TeacherActivityViewModel();
            teacherActivity.StudentsOnActivity = _activitiesService.GetStudentsOnActivity(id);
            teacherActivity.ActivityInfos = _activitiesService.GetActivityInfos(id);

            return View("TeacherActivity", teacherActivity);
        }

        // GET: Activity/Create
        public IActionResult Create()
        {
            ActivityViewModel vm = new ActivityViewModel();
            vm.ActivityTypes = _activitiesService.GetAvailableActivityTypes();
            
            return View(vm);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                activity.ActivityTypes = _activitiesService.GetAvailableActivityTypes(); 
                Activity act = new Activity { Name = activity.Name, Description = activity.Description, Type = activity.SelectedType };

                var id = _authenticationService.GetUserId();

               // _activitiesService.Create(act);
                _activitiesService.CreateActivityForTeacher(id, act);
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        public IActionResult AddStudent()
        {
            var students = _studentsService.GetAllStudents();
            return View("AddStudentToActivity",students);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(int id, StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                Student stud = new Student { Name = student.Name, UserName = student.UserName };

                _studentsService.AddStudentToActivity(id, stud);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Activities/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Activities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ActivityId,StudentId,Grade,Attendance,Date")] StudentsManagement.Domain.StudentActivityInfo activity)
        {
            //if (id != activity.ActivityId)
            //{
            //    return NotFound();
            //}

             activity.ActivityId = id;

            if (ModelState.IsValid)
            {
                _activitiesService.Edit(id, activity);
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var activity = _activitiesService.GetDelete(id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _activitiesService.PostDelete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _activitiesService.StudentExists(id);
        }
    }
}