using HsptMS.Abstraction;
using HsptMS.Data.Models;
using HsptMS.Servise;
using HsptMS.Servises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;

namespace HsptMS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorServise _doctorServise;
        private readonly HmsContext _hmscontext;
    
        public DoctorController(
            IDoctorServise doctorServise,
            HmsContext hmsContext
            )
        {
            _doctorServise = doctorServise;
            _hmscontext = hmsContext;
            
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
            //doctor.Id = GuidExtension.GetGuid();
            //doctor.DepartmentId = GuidExtension.GetGuid();
            var doctorList= _hmscontext.Doctors.ToList();
            ViewBag.DoctorId = new SelectList(doctorList, "Id", "Name");
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

