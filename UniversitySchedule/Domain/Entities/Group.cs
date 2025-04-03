using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Group
    {
        public string GroupName { get; set; }
        public string HigherEducationLevel { get; set; }
        public string FormOfEducation { get; set; }
        public int YearOfAdmission { get; set; }
    }
}
