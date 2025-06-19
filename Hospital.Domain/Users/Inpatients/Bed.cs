namespace Hospital.Domain.Users.Inpatients
{
    public class Bed : EntityBase
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }

        public Room Room { get; set; }
    }
}
