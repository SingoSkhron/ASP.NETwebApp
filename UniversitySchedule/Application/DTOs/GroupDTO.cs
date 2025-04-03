using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string HigherEducationLevel { get; set; }
        public string FormOfEducation { get; set; }
        public int YearOfAdmission { get; set; }
    }
}
