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
}