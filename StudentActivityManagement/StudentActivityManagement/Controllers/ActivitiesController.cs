using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }


        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";

            var activities = _activitiesService.Index();

            return View(activities);
        }
        

        // GET: Activity/Details/5
        public IActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var activity = _activitiesService.Details(id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activity/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _activitiesService.Create(activity);
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
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