using HsptMS.Abstraction;
using HsptMS.Models;
using HsptMS.Servise;
using HsptMS.Servises;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace HsptMS.Controllers
{
    public class DoctorController:Controller
    {
       private readonly IDoctorServise _doctorServise;
        public DoctorController(IDoctorServise doctorServise)
        {
            _doctorServise = doctorServise;
        }


        public ActionResult Index()
        {
            var doctors = _doctorServise.GetAllDoctorss();
            return View(doctors);
        }
         
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            doctor.Id = GuidExtension.GetGuid();
            doctor.DepartmentId = GuidExtension.GetGuid();
            _doctorServise.AddDoctor(doctor);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var doctor =_doctorServise.GetDoctorById(id);
            return View(doctor);
        }
        
        public ActionResult Edit(Guid id)
        {
            var doctor = _doctorServise.GetDoctorById(id);
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            _doctorServise.UpdateDoctor(doctor);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var doctor = _doctorServise.GetDoctorById(id);
            return View(doctor);
        }

        [HttpPost]
        
        public ActionResult DeleteConfirmed(Guid id)
        {
            _doctorServise.DeleteDoctor(id);
            return RedirectToAction("Index");
        }


    }

}

