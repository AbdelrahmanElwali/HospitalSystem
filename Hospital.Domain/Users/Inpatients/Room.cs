namespace Hospital.Domain.Users.Inpatients
{
    public class Room : EntityBase
    {
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }

        public ICollection<Bed> Beds { get; set; }
    }
}
