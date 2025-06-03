using Hospital.Domain;

namespace Hospital.Domain.Users.Doctors
{
    public class Specilization : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DoctorSpecilization> Doctors { get; set; }
        public ICollection<DoctorSpecilization> DoctorSpecilizations { get; set; }

    }
}
