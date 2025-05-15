using FluentValidation;

namespace Application.Requests
{
    public class UpdateAcademicBuildingRequest
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
    public class UpdateAcademicBuildingRequestValidator : AbstractValidator<UpdateAcademicBuildingRequest>
    {
        public UpdateAcademicBuildingRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(ValidationConstants.MaxAddressLength);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ValidationConstants.MaxAcademicBuildingNameLength);
        }
    }
}
