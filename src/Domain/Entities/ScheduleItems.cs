namespace Domain.Entities
{
    public class ScheduleItems
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int DayOfTheWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BuildingId { get; set; }
    }
}
