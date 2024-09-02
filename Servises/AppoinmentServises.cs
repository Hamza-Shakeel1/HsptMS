using HsptMS.Abstraction;
using HsptMS.Models;

namespace HsptMS.Servises
{
	public class AppoinmentServises:IAppoinmentServises
	{
        private static List<Appointment> _appointment = Seed.SeedAppointment();

        public List<Appointment> Appointments()
        {
            return _appointment;
        }
        public void AddAppoinment(Appointment appointment)
        {

            _appointment.Add(appointment);
        }

        public void RemoveAppoinment(Guid id) 
        {
            var appoinments= _appointment.FirstOrDefault(x => x.Id == id);
            if (appoinments != null)
            {
                _appointment.Remove(appoinments);
            }
        }
        public void Update(Appointment appointment) {
        var existAppoinment=_appointment.FirstOrDefault(x => x.Id == appointment.Id);
            if (existAppoinment != null) 
            {
                _appointment.Remove(existAppoinment);
                _appointment.Add(appointment);
            }
        }
        public  Appointment GetAppoinmentById(Guid id) 
        {
            return _appointment.FirstOrDefault(x => x.Id == id);

        }
    }
}
