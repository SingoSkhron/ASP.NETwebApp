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
            RuleFor(x => x.AuditoriumId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BuildingId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.ProfessorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.GroupId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.ScheduleItemId).NotEmpty().GreaterThan(0);
        }
    }
}
