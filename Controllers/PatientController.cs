using Microsoft.AspNetCore.Mvc;
using HsptMS.Data.Models;
using FluentValidation.Results;

using HsptMS.Abstraction;
using HsptMS.Servises;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using FluentValidation.AspNetCore;
using System.Diagnostics.Metrics;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace HsptMS.Controllers
{
    public class PatientController : Controller
    {
        public readonly HmsContext _hmsContext;
        private readonly IPatientService _patientService;
        private readonly IMasterService _masterService;
        private IValidator<Patient> _validator;

        public PatientController(
                 IPatientService patientService,
                 HmsContext hmsContext,
                 IMasterService masterService,
                 IValidator<Patient> validator
            )
        {
            _patientService = patientService;
            _hmsContext = hmsContext;
            _masterService = masterService;
            _validator = validator;

        }

        public async Task<IActionResult> Search(string searchString)
        {
            var patients = await _patientService.Search(searchString);


            return View("Index", patients);
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
            ViewBag.GetDoctors = _masterService.GetDoctors();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }
            _patientService.AddPatient(patient);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            ViewBag.GetDoctors = _masterService.GetDoctors();
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
            _patientService.DeletePatient(id);
            return RedirectToAction("Index");
        }

    }
}