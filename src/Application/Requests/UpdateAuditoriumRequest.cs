using FluentValidation;

namespace Application.Requests
{
    public class UpdateAuditoriumRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public int BuildingId { get; set; }
    }

    public class UpdateAuditoriumRequestValidator : AbstractValidator<UpdateAuditoriumRequest>
    {
        public UpdateAuditoriumRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ValidationConstants.MaxAuditoriumNameLength);
            RuleFor(x => x.FloorNumber).NotEmpty().InclusiveBetween(-10, 50);
            RuleFor(x => x.BuildingId).NotEmpty().GreaterThan(0);
        }
    }
}
