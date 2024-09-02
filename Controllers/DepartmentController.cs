using HsptMS.Abstraction;
using HsptMS.Models;
using HsptMS.Servises;
using Microsoft.AspNetCore.Mvc;

namespace HsptMS.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly IDepartmentServise _departmentServise;
        public DepartmentController(IDepartmentServise departmentServise)
        {
            _departmentServise = departmentServise;
        }

        public ActionResult Index()
        {
           var department=_departmentServise.GetDepartmentList();
            return View(department);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            _departmentServise.AddDepartment(department);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var department = _departmentServise.GetDepartmentById(id);
            return View(department);
        }

        // Perform the actual deletion
        [HttpPost]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _departmentServise.RemoveDepartmentById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            var department=_departmentServise.GetDepartmentById(id);
            return View(department);
        }

        public ActionResult Edit(Guid id)
        {
            var department = _departmentServise.GetDepartmentById(id);
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
           _departmentServise.UpdateDepartment(department);
            return RedirectToAction("Index");
        }

    }
}
