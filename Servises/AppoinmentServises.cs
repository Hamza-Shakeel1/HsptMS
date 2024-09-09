using HsptMS.Abstraction;
using HsptMS.Data.Models;

namespace HsptMS.Servises
{
	public class AppoinmentServises:IAppoinmentServises
	{
        private readonly HmsContext _hmscontext;
        public AppoinmentServises(HmsContext hmscontext)
        {
            _hmscontext= hmscontext;
        }

        public List<Appointment> Appointments()
        {
            return _hmscontext.Appointments.ToList();
        }
        public void AddAppoinment(Appointment appointment)
        {

            _hmscontext.Appointments.Add(appointment);
        }

        public void RemoveAppoinment(Guid id) 
        {
            var appoinments= _hmscontext.Appointments.FirstOrDefault(x => x.Id == id);
            if (appoinments != null)
            {
                _hmscontext.Appointments.Remove(appoinments);
            }
        }
        public void Update(Appointment appointment) {
        var existAppoinment=_hmscontext.Appointments.FirstOrDefault(x => x.Id == appointment.Id);
            if (existAppoinment != null) 
            {
                _hmscontext.Appointments.Remove(existAppoinment);
                _hmscontext.Appointments.Add(appointment);
            }
        }
        public  Appointment GetAppoinmentById(Guid id) 
        {
            return _hmscontext.Appointments.FirstOrDefault(x => x.Id == id);

        }
    }
}
