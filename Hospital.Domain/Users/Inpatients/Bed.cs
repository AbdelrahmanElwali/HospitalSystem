using Hospital.Domain; 
using Hospital.Domain.Users.Rooms;
using Hospital.Domain.Users.Patients;
using Hospital.Domain.Users.Inpatients;

namespace Hospital.Domain.Users.Rooms
{
    public class Bed : EntityBase
    {
        public string BedNumber { get; set; } = string.Empty;  
        public bool IsOccupied { get; set; } = false;          
        public decimal DailyRate { get; set; }                  

       
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

       
        public Guid? PatientStayId { get; set; }
        public PatientStay? PatientStay { get; set; }
    }
}
