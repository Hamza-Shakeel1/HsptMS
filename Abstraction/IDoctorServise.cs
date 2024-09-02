using HsptMS.Models;

namespace HsptMS.Abstraction
{
	public interface IDoctorServise
	{
        List<Doctor> GetAllDoctorss();
        Doctor GetDoctorById(Guid id);
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(Guid id);
        
    }
}
