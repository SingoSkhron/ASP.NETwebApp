using FluentValidation;

namespace Application.Requests
{
    public class UpdateScheduleItemRequest
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int DayOfTheWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int BuildingId { get; set; }
    }

    public class UpdateScheduleItemRequestValidator : AbstractValidator<UpdateScheduleItemRequest>
    {
        public UpdateScheduleItemRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.OrderNumber).NotEmpty().InclusiveBetween(ValidationConstants.MinOrderNumber, ValidationConstants.MaxOrderNumber);
            RuleFor(x => x.DayOfTheWeek).NotEmpty().InclusiveBetween(ValidationConstants.MinDayOfTheWeek, ValidationConstants.MaxDayOfTheWeek);
            RuleFor(x => x.StartTime).NotEmpty().GreaterThanOrEqualTo(new TimeSpan(8, 0, 0)).LessThanOrEqualTo(new TimeSpan(21, 0, 0));
            RuleFor(x => x.EndTime).NotEmpty().GreaterThanOrEqualTo(new TimeSpan(9, 0, 0)).LessThanOrEqualTo(new TimeSpan(22, 0, 0));
            RuleFor(x => x).Must(x => x.StartTime < x.EndTime).WithMessage("StartTime must be earlier than EndTime.");
            RuleFor(x => x.BuildingId).NotEmpty().GreaterThan(0);
        }
    }
}
