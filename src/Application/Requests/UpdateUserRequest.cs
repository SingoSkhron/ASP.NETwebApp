using Domain.Enums;
using FluentValidation;

namespace Application.Requests
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public UserTypeEnum Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AdmissionYear { get; set; }
        public int? GroupId { get; set; }
    }

    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Type).NotEmpty().IsInEnum();
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(ValidationConstants.MaxUserNameLength);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(ValidationConstants.MaxUserNameLength);
            RuleFor(x => x.AdmissionYear).ExclusiveBetween(1950, DateTime.Now.Year);
            RuleFor(x => x.GroupId).GreaterThan(0);
        }
    }
}
