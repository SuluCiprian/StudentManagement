using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentActivityMenagement.Models.ActivityViewModel;
using StudentsManagement.Persistence;

namespace StudentActivityMenagement.Controllers
{
    [Authorize]
    public class ActivitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        private string user = null;

        public ActivitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";

            _unitOfwork.Activities.Insert(new StudentsManagement.Domain.Activity
            {
                Name = "curs"
            });

            _unitOfwork.Activities.Insert(new StudentsManagement.Domain.Activity
            {
                Name = "seminar"
            });

            _unitOfwork.Complete();

            var activities = _unitOfwork.Activities.GetAll();

            return View(activities);
        }

        public IActionResult ViewAll(string user)
        {
            if (user == "student")
            {
                List<string> activitiesName = new List<string>
                {
                    "Activity 1",
                    "Activity 2",
                    "Activity 3"
                };

                List<int> activitiesId = new List<int>
                {
                    1,
                    2,
                    3
                };

                List<string> activitiesType = new List<string>
                {
                    "Curs",
                    "Seminar",
                    "Llaborator"
                };

                List<string> activityDescription = new List<string>
                {
                    "Class 101",
                    "Class 102",
                    "Class 103"
                };

                var model = new Activities
                {
                    ActivitiesName = activitiesName,
                    IdActivities = activitiesId,
                    ActivitiesType = activitiesType,
                    ActivitiesDescription = activityDescription
                };

                return View("StudentActivities", model);
            }
            else
            {
                List<string> activitiesName = new List<string>
                {
                    "Activity 4",
                    "Activity 5",
                    "Activity 6"
                };

                List<int> activitiesId = new List<int>
                {
                    4,
                    5,
                    6
                };

                List<string> activitiesType = new List<string>
                {
                    "S",
                    "L",
                    "C"
                };

                List<string> activityDescription = new List<string>
                {
                    "Class 104",
                    "Class 105",
                    "Class 106"
                };

                var model = new Activities
                {
                    ActivitiesName = activitiesName,
                    IdActivities = activitiesId,
                    ActivitiesType = activitiesType,
                    ActivitiesDescription = activityDescription
                };

                return View("TeacherActivities", model);
            }
        }

        public IActionResult Activity(int? id)
        {
            int idActivity = id ?? default(int);

            if (user == "student")
            {
                List<DateTime> dateTime = new List<DateTime>
                {
                    new DateTime(2018, 5, 4),
                    new DateTime(2018, 5, 5),
                    new DateTime(2018, 5, 6),
                    new DateTime(2018, 5, 7)
                };

                List<double> grade = new List<double>
                {
                    9,
                    7.6,
                    5,
                    8
                };

                List<int> attendance = new List<int>
                {
                    5,
                    2,
                    0,
                    6
                };

                var model = new StudentActivityInfo
                {
                    IdActivity = idActivity,
                    Date = dateTime,
                    Grade = grade,
                    Attendance = attendance
                };

                return View("StudentActivity", model);
            }
            else
            {
                List<int> studentId = new List<int>
                {
                    1,
                    2,
                    3
                };

                List<string> name = new List<string>
                {
                    "Ionel",
                    "Georgel",
                    "Mihai"
                };

                string activityName = "E-learning";

                var model = new AllStudentsOnActivity
                {
                    Id = studentId,
                    Name = name,
                    ActivityName = activityName
                };

                return View("TeacherActivity", model);
            }
        }
    }
}