using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class QuizAttemptDto
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public QuizDto Quiz { get; set; }
        public int UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? FinishAt { get; set; }
        public QuizResultDto? QuizResult { get; set; }
        public List<QuizAnswerDto> QuizAnswers { get; set; } = new List<QuizAnswerDto>();
    }
}
