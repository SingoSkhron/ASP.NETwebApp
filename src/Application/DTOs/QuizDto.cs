using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }//UserId
        public UserDto Author { get; set; }

        public List<QuizQuestionDto> Questions { get; set; }
    }
}
