using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly IUserService userService;

        public ActivitiesController(IActivitiesService activitiesService, IStudentsService studentsService, IAuthenticationService authenticationService, IUserService userService)
        {
            _activitiesService = activitiesService;
            _studentsService = studentsService;
            _authenticationService = authenticationService;
            this.userService = userService;
        }


        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";
            var id = _authenticationService.GetUserId();

            if (_authenticationService.IsUserStudent())
            {
                var activities = _activitiesService.GetStudentActivities(id);
                return View(activities);
            }
            else
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

            var activityInfos = _activitiesService.Details(id);
            var scheduleEntries = _activitiesService.GetScheduleEntries(id);

            if (_authenticationService.IsUserStudent())
            {
                var studentActivity = new StudentActivityViewModel();
                studentActivity.ActivityInfos = activityInfos;
                studentActivity.Schedules = scheduleEntries;
                studentActivity.Type = activity.ToList()[1].Occurance.Activity.Type.Name;
                return View("StudentActivity", studentActivity);
            }
            else
            {
                var teacherActivity = new TeacherActivityViewModel();
                teacherActivity.StudentsOnActivity = _activitiesService.GetStudentsOnActivity(id);
                teacherActivity.ScheduleEntries = scheduleEntries;

                if (activityInfos.ToList().Capacity == 0)
                {
                    List<StudentActivityInfo> infos = new List<StudentActivityInfo>();
                    for (int i = 0; i < scheduleEntries.ToList().Capacity; i++)
                    {
                        foreach (var item in teacherActivity.StudentsOnActivity)
                        {
                            var activityInfo = new StudentActivityInfo { ActivityId = id, StudentId = item.Id, Occurance = scheduleEntries.ElementAt(i) };
                            infos.Add(activityInfo);
                            _activitiesService.Insert(activityInfo);
                        }
                    }
                    teacherActivity.ActivityInfos = infos;
                }
                else
                {
                    teacherActivity.ActivityInfos = activityInfos;
                }
                teacherActivity.Type = activity.ToList()[1].Occurance.Activity.Type.Name;
                return View("TeacherActivity", teacherActivity);
            }
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

            List<Student> students = userService.GetStudents().ToList();
            vm.Students = students;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActivityViewModel activity)
        {
            if (ModelState.IsValid)
            {
                ICollection<Student> studentsList = _studentsService.GetStudentsWithName(activity.StudentNames);

                ICollection<ScheduleEntry> schedule = new List<ScheduleEntry>();
                foreach (var dateString in activity.Occurences)
                {
                    DateTime dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    ScheduleEntry scheduleEntry = new ScheduleEntry { Occurence = dateTime };
                    schedule.Add(scheduleEntry);
                }
                activity.ActivityTypes = _activitiesService.GetAvailableActivityTypes();
                Activity act = new Activity { Id = 0, Name = activity.Name, Description = activity.Description, Type = activity.SelectedType, Schedule = schedule };
                act.StudentsLink = new List<ActivityStudent>();
                foreach (var student in studentsList)
                {
                    act.StudentsLink.Add(new ActivityStudent { Activity = act, Student = student });
                }

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
            return View("AddStudentToActivity", students);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddStudent(int id, StudentViewModel student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Student stud = new Student { Name = student.Name, UserName = student.UserName };

        //        _studentsService.AddStudentToActivity(id, stud);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}

        // GET: Activities/Edit/5
        /*public IActionResult Edit(int id)
        {
            return View();
        }*/

        [HttpGet]
        [Route("Activities/Edit/{id}", Name = "EditGrades")]
        public IActionResult Edit(int id)
        {
            var vm = _activitiesService.GetActivityInfo(id);
            return View("Edit", vm);
        }


        // [Bind("ActivityId,StudentId,Grade,Attendance,Occurance")] StudentsManagement.Domain.StudentActivityInfo activity
        // POST: Activities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Activities/Edit", Name = "SaveGrades")]
        public IActionResult Edit(StudentsManagement.Domain.StudentActivityInfo activity)
        {          

            if (ModelState.IsValid)
            {
               var activityId = _activitiesService.Edit(activity);
                return RedirectToAction("Details", new { id = activityId });
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