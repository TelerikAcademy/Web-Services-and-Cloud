using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Tests.Models;

namespace Tests.Api.Models
{
    public class QuestionRequestModel
    {
        public string Text { get; set; }

        public string Category { get; set; }

        public string Difficulty { get; set; }

        public IEnumerable<string> WrongAnswers { get; set; }

        public IEnumerable<string> CorrectAnswers { get; set; }
    }

    public class QuestionResponseModel
    {
        public static Expression<Func<Question, QuestionResponseModel>> FromQuestion
        {
            get
            {
                return question => new QuestionResponseModel()
                {
                    Text = question.Text,
                    Id = question.Id,
                    Category = question.Category.Name,
                    Answers = question.Answers.Select(ans => ans.Text)
                };
            }
        }

        public IEnumerable<string> Answers { get; private set; }

        public string Category { get; private set; }

        public int Id { get; private set; }

        public string Text { get; private set; }
    }
}