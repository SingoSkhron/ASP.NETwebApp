using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public int NumberInOrder { get; set; }
        public int Auditorium { get; set; }
        public int AcademicBuilding { get; set; }
        public string Discipline { get; set; }
        public string? TypeOfLesson { get; set; }
        public string DayOfTheWeek { get; set; }
        public int ProfessorId { get; set; }
        public int ScheduleId { get; set; }
        public int GroupId { get; set; }
    }
}
