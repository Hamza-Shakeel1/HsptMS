namespace HsptMS.Models
{
    public static class Seed
    {
        public static List<Member> SeedMembers()
        {
            var member = new List<Member>()
            {
                new Member
                {
                    Name="hamza",
                    Email="hamza@gmail.com",
                    Phone="032198432"
                },
                new Member{ Name="saad",Email="saad@gmail.com",Phone="0343523192" },
                new Member{ Name="taha",Email="taha@gmail.com",Phone="0987654332" },

                new Member{ Name="mubeen",Email="mubeen@gmail.com",Phone="123456789" },
            };

            return member;

        }

        

        public static List<Patient> SeedPatients()
        {
            var patient = new List<Patient>() {
            new Patient
            {
                Id = GuidExtension.GetGuid(),
                Name = "John Doe",
                Age = 30,
                Gender=Gender.male,
                ContactNumber = "123-456-7890",
                Email = "john.doe@example.com",
                Address = new Address { StreetNo = "123 Main St", City = "Anytown", Area = "CA" },
                DoctorId = GuidExtension.GetGuid(),
                RegisterDate = DateTime.Now,
                DischargeDate = DateTime.Now
            },
                new Patient
                {
                    Id = GuidExtension.GetGuid(),
                    Name = "Jane Smith",
                    Age = 25,
                    Gender = Gender.female,
                    ContactNumber = "987-654-3210",
                    Email = "jane.smith@example.com",
                    Address = new Address { StreetNo = "456 Elm St", City = "Othertown", Area = "TX" },
                    DoctorId = GuidExtension.GetGuid(),
                    RegisterDate = DateTime.Now.AddDays(-10),
                    DischargeDate = DateTime.Now.AddDays(10)

                }
             };
            return patient;


        } 
    
      


        public static List<Doctor> SeedDoctor() {
            var doctor = new List<Doctor>()
            {
                new Doctor{  Id=GuidExtension.GetGuid(),Name="john",Contact="789028374",Email="john@gmail.com",Experience=1,Spalization=Spalization.Neurology,DepartmentId=GuidExtension.GetGuid(), },
                new Doctor{ Id=GuidExtension.GetGuid(), Name="tom",Contact="753902564",Email="tom@gmail.com",Experience=1,Spalization=Spalization.Neurology,DepartmentId=GuidExtension.GetGuid(), },
                new Doctor{ Id=GuidExtension.GetGuid(),Name ="kathrin",Contact="7012660505",Email="kat@gmail.com",Experience=1,Spalization=Spalization.Orthopedics,DepartmentId=GuidExtension.GetGuid(), },
                new Doctor{ Id=GuidExtension.GetGuid(),Name ="cruse",Contact="7012660505",Email="cruse@gmail.com",Experience=1,Spalization=Spalization.Orthopedics,DepartmentId=GuidExtension.GetGuid(), }


            };
            return doctor;

        }
        public static List<Supplier> Suppliers()
        {
            var supplier = new List<Supplier>()
            {
                new Supplier{ Name ="peter",Email="peter@email.com",Phone="2313342255" ,ProductSupplier="panadol" },
                new Supplier{ Name="parker",Email="parker@gmail.com",Phone ="245056706",ProductSupplier="Penadol Extra"},
                new Supplier{ Name="steve",Email="steve@gmail.com",Phone ="245056706",ProductSupplier="Brufin"},
                new Supplier{ Name="migel",Email="migel@gmail.com",Phone ="245056706",ProductSupplier="Brufin"},
            };
            return supplier;
        }
        public static List<Department> SeedDepartment()
        {
            var department = new List<Department>()
            {
                new Department{
                     Id=GuidExtension.GetGuid(),
                    DepartmentName ="Cardiology",
                    Contact="3560966442",
                    HeadOfDepartment="willem",
                    Doctors=SeedDoctor(),
                },
                new Department{
                     Id=GuidExtension.GetGuid(),
                    DepartmentName ="GeneralMedicine",
                    Contact="32198765",
                    HeadOfDepartment="maerry",
                    Doctors=SeedDoctor(),
                },
                new Department{
                     Id=GuidExtension.GetGuid(),
                    DepartmentName="Sergery",
                    Contact="00133322299",
                    HeadOfDepartment="alisa",

                    Doctors = SeedDoctor(),
                },
            };
            return department;
        }
        public static List<Appointment> SeedAppointment()
        {
            var appointment = new List<Appointment>()
            {
                new Appointment { Id=GuidExtension.GetGuid(),DoctorId=GuidExtension.GetGuid(),PatientId=GuidExtension.GetGuid(), Porpose="checkup",ApoinmentDate=new DateTime(),IsComplete=false },
                new Appointment{Id=GuidExtension.GetGuid(),DoctorId=GuidExtension.GetGuid(),  PatientId=GuidExtension.GetGuid(),Porpose="checkup", ApoinmentDate=new DateTime() ,IsComplete=false}

            };
            return appointment;
        }
        
        public static List<Billing> SeedBilling()
        {
            List<Billing> billings = new List<Billing>
            {
                new Billing

                {   PatientId=GuidExtension.GetGuid(),
                    Id=GuidExtension.GetGuid(),
                    DoctorId=GuidExtension.GetGuid(),
                    Amount=1000,
                    BillingDate=new DateTime(),
                    IsPaid=false
                },
                new Billing
                {
                    Id=GuidExtension.GetGuid(),
					 DoctorId=GuidExtension.GetGuid(),
					PatientId=GuidExtension.GetGuid(),
                    Amount=1000,
                    BillingDate=new DateTime(),
                    IsPaid=false
                }

            };
        	return billings;
        }
    }
}
       