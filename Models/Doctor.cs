namespace HsptMS.Models
    
{
    public enum Spalization
    {
        Cardiology=1,
        Neurology=2,
        GeneralMedicine=3,
        Orthopedics=4
    }
    public class Doctor
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public Spalization Spalization { get; set; }
        public int Experience { get; set; }

        public string Contact { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
