using System;
using System.Collections.Generic;

namespace HsptMS.Models
{
    public partial class Patient
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public Guid DoctorId { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public Address? Address { get; set; }


    }
    public enum Gender
    {     male,
        female,
        others,
    }

    public class Address
    {
        public string? StreetNo { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
    }
}
