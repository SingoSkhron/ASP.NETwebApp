using FluentValidation;

namespace Application.Requests
{
    public class CreateAuditoriumRequest
    {
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public int BuildingId { get; set; }
    }
    public class CreateAuditoriumRequestValidator : AbstractValidator<CreateAuditoriumRequest>
    {
        public CreateAuditoriumRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ValidationConstants.MaxAuditoriumNameLength);
            RuleFor(x => x.FloorNumber).NotEmpty().InclusiveBetween(-500, 500);
            RuleFor(x => x.BuildingId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
        }
    }
}
