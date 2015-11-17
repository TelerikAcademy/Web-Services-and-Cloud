using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;
using Tests.Models;

namespace Tests.Api.Models
{
    [DataContract]
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
                    Answers = question.Answers.Select(answer => answer.Text).ToList()
                };
            }
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Text { get; private set; }

        [DataMember]
        public IEnumerable<string> Answers { get; private set; }

        [DataMember]
        public string Category { get; private set; }
    }
}