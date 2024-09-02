using HsptMS.Abstraction;
using HsptMS.Models;

namespace HsptMS.Servise
{
	public class DoctorServise : IDoctorServise
	{
		private static List<Doctor> _doctors = Seed.SeedDoctor();
		public List<Doctor> GetAllDoctorss()
		{
			return _doctors;
		}
		public Doctor GetDoctorById(Guid id)
		{
			return _doctors.FirstOrDefault(x => x.Id == id);
		}
		public void AddDoctor(Doctor doctor)
		{
			doctor.Id = Guid.NewGuid();
			doctor.DepartmentId= Guid.NewGuid();
			_doctors.Add(doctor);
		}
        public void DeleteDoctor(Guid id)
        {
            var doctor = _doctors.FirstOrDefault(x => x.Id == id);
            if (doctor != null)
            {
                _doctors.Remove(doctor);
            }
        }

        public void UpdateDoctor(Doctor doctor)
		{
			var doctors = _doctors.FirstOrDefault(x => x.Id == doctor.Id);
			if (doctors != null)
			{
				_doctors.Remove(doctors);
				_doctors.Add(doctor);
			}
			
		}

    }
}


