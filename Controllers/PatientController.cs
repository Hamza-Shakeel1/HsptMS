using Microsoft.AspNetCore.Mvc;
using HsptMS.Models;

using System;
using System.Linq;
using HsptMS.Abstraction;

namespace HsptMS.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public ActionResult Index()
        {
            var patients = _patientService.GetAllPatients();
            return View(patients);
        }

        public ActionResult Details(Guid id)
        {
            var patient = _patientService.GetPatientById(id);
            return View(patient);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            _patientService.AddPatient(patient);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var patient = _patientService.GetPatientById(id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            _patientService.UpdatePatient(patient);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var patient = _patientService.GetPatientById(id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _patientService.DeletePatient(id);  // Calls the service to delete the patient
            return RedirectToAction("Index");
        }

    }
}