using Student.Core.Contracts;
using Student.Core.Models;
using Student.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace Student.WebUI.Controllers
{
    public class JobManagerController : Controller
    {
        IRepository<Job> context;
        IRepository<Customer>customers;
        IRepository<Application> applicationContext;

        public JobManagerController(IRepository<Job> context, IRepository<Application> ApplicationContext, IRepository<Customer>customers)
        {
            this.context = context;
            this.applicationContext = ApplicationContext;
            this.customers = customers;
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

        [Authorize]
        public ActionResult ApplyForJob(string jobId)
        {
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);

            if (customer != null)
            {
                Application application = new Application()
                {
                    Email = customer.Email,
                    StudentName = customer.FirstName + " " + customer.LastName,
                    JobId = jobId
                };

                return View(application);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        [HttpPost]
        public ActionResult ApplyForJob(Application application, HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }
            else
            {
                if (file1 != null)
                {
                    application.Image = application.Id + Path.GetExtension(file1.FileName);
                    file1.SaveAs(Server.MapPath("//Content//ApplicantImages//") + application.Image);
                }
                if (file2 != null)
                {
                    application.CV = application.Id + Path.GetExtension(file2.FileName);
                    file2.SaveAs(Server.MapPath("//Content//ApplicationImages//") + application.CV);
                }
                applicationContext.Insert(application);
                applicationContext.Commit();
            }

            //Find dthe customer details
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name); //Returns the user
            string fname = customer.FirstName; //name

            //Find Job Email
            var Job = context.Find(application.JobId);
            string jobEmail = Job.Email;

                string from = "campuswork2021@outlook.com";
                string to = jobEmail;
                string subject = "Student Hub Student Application";
                string body = "Good Day. We have a promising student that is interested in one of your available jobs. Please have a look at their attached CV.Kind Regards The Student Hub Team ";


                using (MailMessage mail = new MailMessage(from, to))
                {
                    mail.Subject = subject;
                    mail.Body = body;
                    if (file2 != null)
                    {
                        string fileName = Path.GetFileName(file2.FileName);
                        mail.Attachments.Add(new Attachment(file2.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "Campuswork");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                }

            return RedirectToAction("ThankYou");
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
        public ActionResult ThankYou()
        {
           

            //string subject = "Student Hub Confirmation  ";
            //string message = "Hi " + fname + " We have received your application and we will be in contact soon!";

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var senderEmail = new MailAddress("campuswork2021@outlook.com", "Student Hub");
            //        var receiverEmail = new MailAddress(receiver, "Receiver");
            //        var password = "Campuswork";
            //        var sub = subject;
            //        var body = message;
            //        var smtp = new SmtpClient
            //        {
            //            Host = "smtp-mail.outlook.com",
            //            Port = 587,
            //            EnableSsl = true,
            //            DeliveryMethod = SmtpDeliveryMethod.Network,
            //            UseDefaultCredentials = false,
            //            Credentials = new NetworkCredential(senderEmail.Address, password)
            //        };
            //        using (var mess = new MailMessage(senderEmail, receiverEmail)
            //        {
            //            Subject = subject,
            //            Body = body
            //        })
            //        {
            //            smtp.Send(mess);
            //        }
            //        return View();
            //    }
            //}
            //catch (Exception)
            //{
            //    ViewBag.Error = "Some Error";
            //}

            return View();
        }
    }
}

