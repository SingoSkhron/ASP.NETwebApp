using Domain.Enums;

namespace Application.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public EducationFormEnum EducationForm { get; set; }
        public int AdmissionYear { get; set; }
    }
}
