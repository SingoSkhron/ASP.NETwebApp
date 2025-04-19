using Domain.Enums;

namespace Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public EducationFormEnum EducationForm { get; set; }
        public int AdmissionYear { get; set; }
    }
}
