using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }//UserId
        public User Author { get; set; } 

        public List<QuizQuestion> Questions { get; set; }

    }
}
