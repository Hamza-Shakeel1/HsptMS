using HsptMS.Models;
namespace HsptMS.Abstraction

{


    public interface IPatientService
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(Guid id);
        void UpdatePatient(Patient patient);
        void DeletePatient(Guid id);
        void AddPatient(Patient patient);


    }       
    
}

