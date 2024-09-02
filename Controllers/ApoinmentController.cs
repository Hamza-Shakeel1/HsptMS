using HsptMS.Abstraction;
using HsptMS.Models;
using HsptMS.Servises;
using Microsoft.AspNetCore.Mvc;

namespace HsptMS.Controllers
{
    public class ApoinmentController:Controller
    {
		private readonly IAppoinmentServises _appoinmentServises;

        public ApoinmentController(IAppoinmentServises appoinmentServises)
        {
            _appoinmentServises = appoinmentServises;
        }

        public ActionResult Index()
        {
            var appoinments= _appoinmentServises.Appointments();
            return View(appoinments);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Appointment appointment) 
        {
            _appoinmentServises.AddAppoinment(appointment);
            
            return RedirectToAction("Index");
        }


        public ActionResult Delete(Guid Id) 
        {
            var appoinment=_appoinmentServises.GetAppoinmentById(Id);
            return View(appoinment);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            _appoinmentServises.RemoveAppoinment(Id);    
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id) 
        {
            var appointment = _appoinmentServises.GetAppoinmentById(Id);
            return View(appointment);
        }
        [HttpPost]
        public ActionResult Edit(Appointment appointment) 
        {
          _appoinmentServises.Update(appointment);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id) 
        {
            var appointment = _appoinmentServises.GetAppoinmentById(id);
            return View(appointment);
        }


    }
}
