using HsptMS.Abstraction;
using HsptMS.Models;

namespace HsptMS.Servises
{
	public class DepartmentServise:IDepartmentServise
	{
        private static List<Department> _departmentList = Seed.SeedDepartment();
        public List<Department> GetDepartmentList ()
        {
            return _departmentList;
        }
        public void AddDepartment(Department department)
        {
            department.Id = GuidExtension.GetGuid();
            _departmentList.Add(department);
        }
        public Department GetDepartmentById(Guid id)
        {
            return _departmentList.FirstOrDefault(x => x.Id == id);
        }
        public void RemoveDepartmentById(Guid id)
        {
            var department = _departmentList.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                _departmentList.Remove(department);
            }
        }



        public void UpdateDepartment(Department department)
        {
            var existingDepartment = _departmentList.FirstOrDefault(x => x.Id == department.Id);
            if (existingDepartment != null)
            {
                _departmentList.Remove(existingDepartment);
                _departmentList.Add(department);
            }
        }

    }
}
