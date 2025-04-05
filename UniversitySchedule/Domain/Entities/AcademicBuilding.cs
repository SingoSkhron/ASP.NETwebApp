using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AcademicBuilding
    {
        public int Id { get; set; }
        public TimeOnly LessonsStartTime { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public TimeOnly BigBreakDuration { get; set; }
    }
}
