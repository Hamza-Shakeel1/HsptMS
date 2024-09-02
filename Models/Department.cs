namespace HsptMS.Models
{
    public class Department
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string? DepartmentName { get; set; }
        public Guid DoctorId { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; } = Guid.NewGuid();
        public string? HeadOfDepartment { get; set; }

        public string? Contact {  get; set; }
        public List<Doctor>? Doctors { get; set; }
    }
}
