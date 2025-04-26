using Domain.Enums;

namespace Application.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LessonTypeEnum LessonType { get; set; }
        public int AuditoriumId { get; set; }
        public int BuildingId { get; set; }
        public int ProfessorId { get; set; }
        public int GroupId { get; set; }
        public int ScheduleItemId { get; set; }
    }
}
