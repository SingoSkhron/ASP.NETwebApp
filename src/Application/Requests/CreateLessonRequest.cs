using Domain.Enums;
using FluentValidation;

namespace Application.Requests
{
    public class CreateLessonRequest
    {
        public string Name { get; set; }
        public LessonTypeEnum LessonType { get; set; }
        public int AuditoriumId { get; set; }
        public int BuildingId { get; set; }
        public int ProfessorId { get; set; }
        public int GroupId { get; set; }
        public int ScheduleItemId { get; set; }
    }
    public class CreateLessonRequestValidator : AbstractValidator<CreateLessonRequest>
    {
        public CreateLessonRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ValidationConstants.MaxLessonNameLength);
            RuleFor(x => x.LessonType).NotEmpty().IsInEnum();
            RuleFor(x => x.AuditoriumId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.BuildingId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.ProfessorId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.GroupId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.ScheduleItemId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
        }
    }
}
