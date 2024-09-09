using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HsptMS.Data.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            Billings = new HashSet<Billing>();
        }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int Age { get; set; }
        [Required]
        public int? Gender { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? DoctorId { get; set; }
        [Required]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public DateTime? DischargeDate { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Billing> Billings { get; set; }
    }
}
