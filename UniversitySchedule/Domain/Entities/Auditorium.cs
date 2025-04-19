namespace Domain.Entities
{
    public class Auditorium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public int BuildingId { get; set; }
    }
}
