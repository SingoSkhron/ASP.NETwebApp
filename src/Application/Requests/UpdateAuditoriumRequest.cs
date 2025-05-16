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
            RuleFor(x => x.Id).NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ValidationConstants.MaxAuditoriumNameLength);
            RuleFor(x => x.FloorNumber).NotEmpty().InclusiveBetween(-500, 500);
            RuleFor(x => x.BuildingId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
        }
    }
}
