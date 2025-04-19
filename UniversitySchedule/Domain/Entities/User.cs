using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public UserTypeEnum Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AdmissionYear { get; set; }
        public int? GroupId { get; set; }
    }
}
