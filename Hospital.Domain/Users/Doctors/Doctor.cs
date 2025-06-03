namespace Hospital.Domain.Users.Doctors
{
    public class Doctor : UserBase
    {
        public List<DoctorSpecilization> Specilizations { get; set; }
        public ICollection<DoctorSpecilization> DoctorSpecilizations { get; set; }

    }
}
