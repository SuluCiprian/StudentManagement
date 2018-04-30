using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentActivityMenagement.Models.ActivityViewModel;
using StudentsManagement.Core.Shared;
using StudentsManagement.Domain;
using System.Globalization;

namespace StudentActivityMenagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IActivitiesService _activitiesService;
        private readonly ITeacherService _teacherService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService userService;
        private readonly IStudentsService _studentsService;

        public TeacherController(
            IActivitiesService activitiesService,
            ITeacherService teacherService,
            IAuthenticationService authenticationService,
            IStudentsService studentsService,
            IUserService userService)
        {
            _activitiesService = activitiesService;
            _teacherService = teacherService;
            _authenticationService = authenticationService;
            _studentsService = studentsService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var id = _authenticationService.GetUserId();
            var activities = _teacherService.GetTeacherActivities(id);
            return View(activities);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var activityInfos = _activitiesService.Details(id);
                var scheduleEntries = _activitiesService.GetScheduleEntries(id);

                var teacherActivity = new TeacherActivityViewModel();
                teacherActivity.StudentsOnActivity = _teacherService.GetStudentsOnActivity(id);
                teacherActivity.ScheduleEntries = scheduleEntries;

                if (activityInfos.ToList().Capacity == 0)
                {
                    List<StudentActivityInfo> infos = new List<StudentActivityInfo>();
                    for (int i = 0; i < scheduleEntries.ToList().Capacity; i++)
                    {
                        foreach (var item in teacherActivity.StudentsOnActivity)
                        {
                            var activityInfo = new StudentActivityInfo { ActivityId = id, StudentId = item.Id, Occurence = scheduleEntries.ElementAt(i) };
                            infos.Add(activityInfo);
                            _teacherService.Insert(activityInfo);
                        }
                    }
                    teacherActivity.ActivityInfos = infos;
                }
                else
                {
                    teacherActivity.ActivityInfos = activityInfos;
                }
                var act = _studentsService.GetActivityById(id);
                ViewData["Name"] = act.Type.Name;
                return View("TeacherActivity", teacherActivity);
            }
        }

        // GET: Activity/Create
        public IActionResult Create()
        {
            ActivityViewModel vm = new ActivityViewModel();
            vm.ActivityTypes = _teacherService.GetAvailableActivityTypes();

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
                activity.ActivityTypes = _teacherService.GetAvailableActivityTypes();
                Activity act = new Activity { Id = 0, Name = activity.Name, Description = activity.Description, Type = activity.SelectedType, Schedule = schedule };
                act.StudentsLink = new List<ActivityStudent>();
                foreach (var student in studentsList)
                {
                    act.StudentsLink.Add(new ActivityStudent { Activity = act, Student = student });
                }

                var id = _authenticationService.GetUserId();

                // _activitiesService.Create(act);
                _teacherService.CreateActivityForTeacher(id, act);

                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        [HttpGet]
        [Route("Activities/EditActivity/{activityId}", Name = "EditActivity")]
        public IActionResult EditActivity(int activityId)
        {
            Activity activity = _teacherService.getActivity(activityId);

            ActivityViewModel vm = new ActivityViewModel { Name = activity.Name, Description = activity.Description, Students = _teacherService.GetStudentsOnActivity(activityId), SelectedTypeId = activity.Type.Id };
            vm.ActivityTypes = _teacherService.GetAvailableActivityTypes();
            vm.Students = _teacherService.GetStudentsOnActivity(activityId);
            vm.Schedule = activity.Schedule;
            return View("Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditActivity(ActivityViewModel activity)
        {
            return null;
        }

        [HttpGet]
        [Route("Activities/Edit/{id}", Name = "EditGrades")]
        public IActionResult Edit(int id)
        {
            var vm = _teacherService.GetActivityInfo(id);
            return View("EditGrades", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Activities/Edit", Name = "SaveGrades")]
        public IActionResult Edit(StudentsManagement.Domain.StudentActivityInfo activity)
        {

            if (ModelState.IsValid)
            {
                var activityId = _teacherService.Edit(activity);
                return RedirectToAction("Details", new { id = activityId });
            }
            return View(activity);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int id)
        {
            var activity = _teacherService.GetDelete(id);
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
            _teacherService.PostDelete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _teacherService.StudentExists(id);
        }
    }
}