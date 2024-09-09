using HMS.Data.Extensions;
using HsptMS.Abstraction;
using HsptMS.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HsptMS.Servises
{
	public class DepartmentServise:IDepartmentServise
	{
        private readonly HmsContext _hmscontext;
        public DepartmentServise(HmsContext hmscontext)
         {
            _hmscontext= hmscontext;
        }
        
        public  List<Department> GetDepartmentList ()
        {
            return _hmscontext.Departments
                .ToList();
        }
        public void AddDepartment(Department department)
        {
            department.Id = GuidExtension.GetGuid();

            _hmscontext.Departments.Add(department);
        }
        public Department GetDepartmentById(Guid id)
        {
            return _hmscontext.Departments.FirstOrDefault(x => x.Id == id);
        }
        public void RemoveDepartmentById(Guid id)
        {
            var department = _hmscontext.Departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                _hmscontext.Departments.Remove(department);
            }
        }



        public void UpdateDepartment(Department department)
        {
            var existingDepartment = _hmscontext.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (existingDepartment != null)
            {
                _hmscontext.Departments.Remove(existingDepartment);
                _hmscontext.Departments.Add(department);
            }
        }

    }
}
