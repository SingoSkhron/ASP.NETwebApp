namespace Domain.Entities
{
    public class ScheduleItems
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int DayOfTheWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int BuildingId { get; set; }
    }
}
