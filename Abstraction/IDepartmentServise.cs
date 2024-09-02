using HsptMS.Models;

namespace HsptMS.Abstraction
{
	public interface IDepartmentServise 
	{
        List<Department> GetDepartmentList();
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        Department GetDepartmentById(Guid id);
        void RemoveDepartmentById(Guid id);



    }
}
