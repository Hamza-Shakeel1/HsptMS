namespace HsptMS.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        public Guid DoctorId { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; } = Guid.NewGuid();
        public DateTime ApoinmentDate { get; set; }
        public string Porpose { get; set; }
        public DateTime ApoinmentTime { get; set; }
        public bool IsComplete { get; set; }



    }
}
