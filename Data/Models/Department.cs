﻿using System;
using System.Collections.Generic;

namespace HsptMS.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            Doctors = new HashSet<Doctor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? HeadOfDepartment { get; set; }
        public string? ContactNumber { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
