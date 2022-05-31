using Student.Core.Contracts;
using Student.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.WebUI.Controllers
{
    public class AppointmentManagerController : Controller
    {
        IRepository<Appointment> context;
        public AppointmentManagerController(IRepository<Appointment> context)
        {
            this.context = context;
        }
        // GET: ListingManager
        public ActionResult Index()
        {
            List<Appointment> appointment = context.Collection().ToList();
            return View(appointment);
        }

        public ActionResult Create()
        {
            Appointment appointment = new Appointment();
            return View(appointment);
        }
        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }
            else
            {
                context.Insert(appointment);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Appointment appointment = context.Find(Id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(appointment);
            }
        }
        [HttpPost]
        public ActionResult Edit(Appointment appointment, string Id)
        {
            Appointment appointmentToEdit = context.Find(Id);
            if (appointmentToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(appointment);
                }

                appointmentToEdit.StudentName = appointment.StudentName;
                appointmentToEdit.PropertyId = appointment.PropertyId;
                appointmentToEdit.DateTime = appointment.DateTime;
                appointmentToEdit.Address = appointment.Address;


                context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            Appointment appointmentToDelete = context.Find(Id);

            if (appointmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(appointmentToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Appointment appointmentToDelete = context.Find(Id);

            if (appointmentToDelete == null)
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