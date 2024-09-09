using HMS.Data.Extensions;
using HsptMS.Abstraction;
using HsptMS.Data.Models;
using Microsoft.EntityFrameworkCore;



namespace HsptMS.Servises
{
    public class PatientService : IPatientService
    {

        private readonly HmsContext _hmscontext;
        public PatientService(HmsContext hmscontext)
        {
            _hmscontext = hmscontext;
        }

        public List<Patient> GetAllPatients()
        {
            return _hmscontext.Patients
                //.Include(p => p.Doctor)
                .ToList();
        }

        public Patient GetPatientById(Guid id) 
        {
            return _hmscontext.Patients.FirstOrDefault(x => x.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            patient.Id = GuidExtension.GetGuid();

            _hmscontext.Patients.Add(patient);
            _hmscontext.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            var existingPatient = _hmscontext.Patients.FirstOrDefault(x => x.Id == patient.Id);
            if (existingPatient != null)
            {
                _hmscontext.Patients.Remove(existingPatient);
                _hmscontext.Patients.Add(patient);
                _hmscontext.SaveChanges();
            }
        }

        public void DeletePatient(Guid id)
        {
            var patient = _hmscontext.Patients.FirstOrDefault(x => x.Id == id);
            if (patient != null)
            {
                _hmscontext.Patients.Remove(patient);
                _hmscontext.SaveChanges();  
            }
        }
        public async Task<List<Patient>> Search(string nameSearch)
        {
            var results = string.IsNullOrWhiteSpace(nameSearch)
                ? await _hmscontext.Patients.ToListAsync() : await _hmscontext.Patients.
                Where(p => p.Name != null && p.Name.Contains(nameSearch)).ToListAsync();
            return results;
        }


    }
}
