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
        private readonly IUnitOfWork _unitOfwork;
        private readonly IActivitiesService _activitiesService;
        private string user = null;

        public ActivitiesController(IUnitOfWork unitOfWork, IActivitiesService activitiesService)
        {
            _unitOfwork = unitOfWork;
            _activitiesService = activitiesService;
        }


        public IActionResult Index()
        {
            ViewData["Message"] = "Your application activities page.";

            var activities = _activitiesService.Index();

            return View(activities);
        }
        

        // GET: Students/Details/5
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

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Students/Edit/5
        public IActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            return View();

            //var activity = _unitOfwork.StudentActivityInfo.GetById(id);
            //if (activity == null)
            //{
            //    return NotFound();
            //}
            //return View(activity);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // POST: Students/Delete/5
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