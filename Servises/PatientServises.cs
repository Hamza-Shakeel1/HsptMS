using HsptMS.Abstraction;
using HsptMS.Models;



namespace HsptMS.Servises
{
    public class PatientService : IPatientService
    {

        private static List<Patient> _patients = Seed.SeedPatients();

        public List<Patient> GetAllPatients()
        {
            return _patients;
        }

        public Patient GetPatientById(Guid id) 
        {
            return _patients.FirstOrDefault(x => x.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            patient.Id = GuidExtension.GetGuid();
            patient.DoctorId=GuidExtension.GetGuid();
            patient.DepartmentId=GuidExtension.GetGuid();
            _patients.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            var existingPatient = _patients.FirstOrDefault(x => x.Id == patient.Id);
            if (existingPatient != null)
            {
                _patients.Remove(existingPatient);
                _patients.Add(patient);
            }
        }

        public void DeletePatient(Guid id)
        {
            var patient = _patients.FirstOrDefault(x => x.Id == id);
            if (patient != null)
            {
                _patients.Remove(patient);
            }
        }


    }
}
