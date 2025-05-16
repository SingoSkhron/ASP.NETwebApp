using FluentValidation;

namespace Application.Requests
{
    public class UpdateScheduleItemRequest
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int DayOfTheWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int BuildingId { get; set; }
    }
    public class UpdateScheduleItemRequestValidator : AbstractValidator<UpdateScheduleItemRequest>
    {
        public UpdateScheduleItemRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().ExclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.OrderNumber).NotEmpty().ExclusiveBetween(0, 8);
            RuleFor(x => x.DayOfTheWeek).NotEmpty().ExclusiveBetween(0, 8);
            RuleFor(x => x.StartTime).NotEmpty().GreaterThanOrEqualTo(new TimeOnly(8, 0)).LessThanOrEqualTo(new TimeOnly(21, 0));
            RuleFor(x => x.EndTime).NotEmpty().GreaterThanOrEqualTo(new TimeOnly(9, 0)).LessThanOrEqualTo(new TimeOnly(22, 0));
            RuleFor(x => x.BuildingId).NotEmpty().ExclusiveBetween(0, int.MaxValue);
        }
    }
}
