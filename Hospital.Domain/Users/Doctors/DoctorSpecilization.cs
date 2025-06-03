namespace Hospital.Domain.Users.Doctors
{
    public class DoctorSpecilization
    {
        /// <summary>
        /// Identifier of the doctor associated with the operation.
        /// </summary>
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        /// <summary>
        /// Identifier of the operation to which this doctor note is linked.
        /// </summary>
        public Guid SpecilizationId { get; set; }
        public Specilization Specilization { get; set; }
    }
}
