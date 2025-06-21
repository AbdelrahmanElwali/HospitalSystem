using Hospital.Domain; 
using Hospital.Domain.Users.Inpatients;
using System.Collections.Generic;

namespace Hospital.Domain.Users.Rooms
{
    public class Room : EntityBase
    {
        public string RoomNumber { get; set; } = string.Empty; 
        public int Capacity { get; set; }                    
        public string RoomType { get; set; } = string.Empty;   
        public string Status { get; set; } = "Available";      


        public ICollection<Bed> Beds { get; set; } = new List<Bed>();
    }
}
