using FluentValidation;

namespace Application.Requests
{
    public class CreateAcademicBuildingRequest
    {
        public string Address { get; set; }
        public string Name { get; set; }
    }
    public class CreateAcademicBuildingRequestValidator : AbstractValidator<CreateAcademicBuildingRequest>
    {
        public CreateAcademicBuildingRequestValidator()
        {
            RuleFor(x => x.Address).NotEmpty().MaximumLength(ValidationConstants.MaxAddressLength);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ValidationConstants.MaxAcademicBuildingNameLength);
        }
    }
}
