using HsptMS.Abstraction;
using HsptMS.Data.Models;

namespace HsptMS.Servise
{
    public class DoctorServise : IDoctorServise
	{
        private readonly HmsContext _hmscontext;
        public DoctorServise(HmsContext hmscontext)
        {
            _hmscontext = hmscontext;
        }
        public List<Doctor> GetAllDoctorss()
		{
            return _hmscontext.Doctors
                
                .ToList();
	
		}
		public Doctor GetDoctorById(Guid id)
		{
            var patient = GetAllDoctorss();
            return _hmscontext.Doctors.FirstOrDefault(x => x.Id == id);
		}
        public void AddDoctor(Doctor doctor)
        {
            // Make sure doctor.Id is being set correctly if needed
            // Example: Ensure the GUID is generated properly if it's not set
            doctor.Id = Guid.NewGuid();

            _hmscontext.Doctors.Add(doctor);
            _hmscontext.SaveChanges();
        }

        public void DeleteDoctor(Guid id)
        {
            var doctor = _hmscontext.Doctors.FirstOrDefault(x => x.Id == id);
            if (doctor != null)
            {
                // Set the DoctorId to null for all associated patients
                var patients = _hmscontext.Patients.Where(p => p.DoctorId == id).ToList();
                foreach (var patient in patients)
                {
                    patient.DoctorId = null;
                }

                _hmscontext.SaveChanges(); // Save changes to update the patients

                _hmscontext.Doctors.Remove(doctor);
                _hmscontext.SaveChanges(); // Save changes to delete the doctor
            }
        }


        public void UpdateDoctor(Doctor doctor)
		{
			var doctors = _hmscontext.Doctors.FirstOrDefault(x => x.Id == doctor.Id);
			if (doctors != null)
			{
				_hmscontext.Doctors.Remove(doctors);
				_hmscontext.Doctors     .Add(doctor);
			}
            _hmscontext.SaveChanges();
        }

    }
}


