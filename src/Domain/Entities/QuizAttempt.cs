using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? FinishAt { get; set; }
        public QuizResult? QuizResult { get; set; }
        public List<QuizAnswer> QuizAnswers { get; set; } = new List<QuizAnswer>();
    }
}
