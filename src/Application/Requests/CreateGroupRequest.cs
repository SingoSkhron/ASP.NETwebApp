using Domain.Enums;
using FluentValidation;

namespace Application.Requests
{
    public class CreateGroupRequest
    {
        public string GroupName { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public EducationFormEnum EducationForm { get; set; }
        public int AdmissionYear { get; set; }
    }

    public class CreateGroupRequestValidator : AbstractValidator<CreateGroupRequest>
    {
        public CreateGroupRequestValidator()
        {
            RuleFor(x => x.GroupName).NotEmpty().MaximumLength(ValidationConstants.MaxGroupNameLength);
            RuleFor(x => x.EducationLevel).NotEmpty().IsInEnum();
            RuleFor(x => x.EducationForm).NotEmpty().IsInEnum();
            RuleFor(x => x.AdmissionYear).NotEmpty().ExclusiveBetween(1970, DateTime.Now.Year);
        }
    }
}
