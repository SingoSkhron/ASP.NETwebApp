using Domain.Enums;
using FluentValidation;

namespace Application.Requests
{
    public class CreateUserRequest
    {
        public UserTypeEnum Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AdmissionYear { get; set; }
        public int? GroupId { get; set; }
    }
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Type).NotEmpty().IsInEnum();
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(ValidationConstants.MaxUserNameLength);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(ValidationConstants.MaxUserNameLength);
            RuleFor(x => x.AdmissionYear).ExclusiveBetween(1950, int.MaxValue);
            RuleFor(x => x.GroupId).ExclusiveBetween(0, int.MaxValue);
        }
    }
}
