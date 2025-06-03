namespace Hospital.Domain.MedicalComplex.Surgeries
{
    /// <summary>
    /// Represents information related to the doctor responsible for a specific medical operation,
    /// including whether the doctor is internal or external, and related references.
    /// </summary>
    public class SurgeryDoctor
    {
        /// <summary>
        /// Identifier of the doctor associated with the operation.
        /// </summary>
        public Guid DoctorId { get; set; }
        /// <summary>
        /// Identifier of the operation to which this doctor note is linked.
        /// </summary>
        public Guid SurgeryId { get; set; }
    }
}
