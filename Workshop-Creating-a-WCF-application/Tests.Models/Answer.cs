using System.ComponentModel.DataAnnotations;

namespace Tests.Models
{
    public class Answer
    {
        public Answer()
           : this(string.Empty, false)
        {
        }

        public Answer(string text)
            : this(text, false)
        {
        }

        public Answer(string text, bool isCorrect)
        {
            this.Text = text;
            this.IsCorrect = isCorrect;
        }

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}