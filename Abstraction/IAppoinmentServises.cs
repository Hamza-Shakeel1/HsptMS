using HsptMS.Models;

namespace HsptMS.Abstraction
{
	public interface IAppoinmentServises
	{
        List<Appointment> Appointments();
        void AddAppoinment(Appointment appointment);
        void RemoveAppoinment(Guid id);
        void Update(Appointment appointment);
        Appointment GetAppoinmentById(Guid id);

    }
}
