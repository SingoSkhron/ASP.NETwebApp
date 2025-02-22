using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuizAnswer
    {
        public int Id { get; set; }
        public int QuizAttemptId { get; set; }
        public int QuestionId { get; set; }
        public QuizQuestion Question { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}
