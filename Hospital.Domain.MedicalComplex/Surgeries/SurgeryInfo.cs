
namespace Hospital.Domain.MedicalComplex.Surgeries
{
    /// <summary>
    /// Represents detailed information about a patient's medical operation, 
    /// including admission and discharge times, operation status, and financial details.
    /// </summary>
    public class SurgeryInfo : EntityBase
    {

        /// <summary>
        /// The date the patient was admitted for the operation.
        /// </summary>
        public DateTime AdmissionDate { get; set; }

        /// <summary>
        /// The time the patient was admitted for the operation.
        /// </summary>
        public TimeSpan AdmissionTime { get; set; }

        /// <summary>
        /// The date the patient was discharged after the operation.
        /// </summary>
        public DateTime DischargeDate { get; set; }

        /// <summary>
        /// The time the patient was discharged after the operation.
        /// </summary>
        public TimeSpan DischargeTime { get; set; }

        /// <summary>
        /// The total duration of the operation.
        /// </summary>
        public TimeSpan SurgeryDuration { get; set; }

        /// <summary>
        /// The current status of the operation (e.g., Pending, Completed, Cancelled).
        /// </summary>
        public string SurgeryStatus { get; set; }

        /// <summary>
        /// Unique identifier for the patient associated with this operation.
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Identifier for the clinic where the operation was performed.
        /// </summary>
        public int ClinicId { get; set; }

        /// <summary>
        /// Identifier for the room assigned to the patient during the operation.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Identifier for the bed used during the patient's stay.
        /// </summary>
        public int BedId { get; set; }

        /// <summary>
        /// The total cost of the operation before discounts.
        /// </summary>
        public decimal SurgeryCost { get; set; }

        /// <summary>
        /// The discount applied to the operation cost.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total cost after applying the discount.
        /// </summary>
        public decimal AfterDiscount { get; set; }

        /// <summary>
        /// The full amount required for the operation.
        /// </summary>
        public decimal TotalRequired { get; set; }

        /// <summary>
        /// The amount that has already been paid by the patient.
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// The remaining amount the patient needs to pay.
        /// </summary>
        public decimal RemainingAmount { get; set; }
    }

}
