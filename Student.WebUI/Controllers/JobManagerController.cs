using Student.Core.Contracts;
using Student.Core.Models;
using Student.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class JobManagerController : Controller
    {
        IRepository<Job> context;
        public JobManagerController(IRepository<Job> context)
        {
            this.context = context;
        }
        // GET: JobManager
        public ActionResult Index()
        {
            List<Job> job = context.Collection().ToList();
            return View(job);
        }
        public ActionResult BrowseJobs()
        {
            List<Job> jobs;

            jobs = context.Collection().ToList();

            JobViewModel model = new JobViewModel();
            model.Jobs = jobs;

            return View(model);
        }

        public ActionResult Create()
        {
            Job job = new Job();
            return View(job);
        }
        [HttpPost]
        public ActionResult Create(Job job, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(job);
            }
            else
            {
                if (file != null)
                {
                    job.Image = job.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//JobImages//") + job.Image);
                }
                context.Insert(job);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Job job = context.Find(Id);
            if (job == null)
            {
                return HttpNotFound();
            }
            else
            {
                JobViewModel viewModel = new JobViewModel();
                viewModel.Job = job;
                return View(job);
            }
        }
        [HttpPost]
        public ActionResult Edit(Job job, string Id,HttpPostedFileBase file)
        {
            Job jobToEdit = context.Find(Id);
            if (jobToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(job);
                }
                if (file != null)
                {
                    jobToEdit.Image = job.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//JobImages//") + jobToEdit.Image);
                }
                jobToEdit.Email = job.Email;
                jobToEdit.JobPosition = job.JobPosition;
                jobToEdit.SalaryOffered = job.SalaryOffered;
                jobToEdit.BusinessName = job.BusinessName;
                jobToEdit.Experience = job.Experience;
                jobToEdit.University = job.University;
                jobToEdit.Vaccinated = job.Vaccinated;
                jobToEdit.ShiftTimes = job.ShiftTimes;


                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Job jobToDelete = context.Find(Id);

            if (jobToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(jobToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Job jobToDelete = context.Find(Id);

            if (jobToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }


    }
}