using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string EducationLevel { get; set; }
        public string EducationForm { get; set; }
        public int AdmissionYear { get; set; }
    }
}
