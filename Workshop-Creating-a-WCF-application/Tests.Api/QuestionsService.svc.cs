using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tests.Api.Models;
using Tests.Data;
using Tests.Data.UnitsOfWork;
using Tests.Models;

namespace Tests.Api
{
    public class QuestionsService : IQuestionsService
    {
        private EfUnitOfWork data;

        public QuestionsService()
        {
            var dbContext = new TestsDbContext();
            this.data = new EfUnitOfWork(dbContext);
        }

        public QuestionResponseModel AddQuestion(QuestionRequestModel model)
        {
            SetCorrectContentType();

            //validation

            var question = new Question();

            question.Text = model.Text;
            question.Category = this.LoadOrCreateCategory(model.Category);
            question.DifficultyLevel = (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), model.Difficulty);
            question.Answers = this.GetAnswersFrom(model);

            this.data.Get<Question>()
                .Add(question);

            this.data.SaveChanges();

            return QuestionResponseModel.FromQuestion
                    .Compile().Invoke(question);
        }

        private ICollection<Answer> GetAnswersFrom(QuestionRequestModel model)
        {
            var answers = new List<Answer>();
            model.CorrectAnswers
                .Select(text => new Answer
                {
                    Text = text,
                    IsCorrect = true
                })
                .ForEach(answers.Add);

            model.WrongAnswers
                .Select(text => new Answer
                {
                    Text = text,
                    IsCorrect = false
                })
                .ForEach(answers.Add);

            return answers;
        }

        private Category LoadOrCreateCategory(string categoryName)
        {
            var category = this.data.Get<Category>()
                    .All()
                    .FirstOrDefault(cat => cat.Name.ToLower() == categoryName.ToLower());

            if (category == null)
            {
                category = new Category()
                {
                    Name = categoryName
                };
            }

            return category;
        }

        public IQueryable<QuestionResponseModel> GetAll()
        {
            SetCorrectContentType();

            return this.data.Get<Question>()
                    .All()
                    .Select(QuestionResponseModel.FromQuestion)
                    .ToList()
                    .AsQueryable();
        }

        public QuestionResponseModel GetById(string id)
        {
            //validation for id

            var question = this.data.Get<Question>()
                     .GetById(int.Parse(id));

            return QuestionResponseModel.FromQuestion
                    .Compile()
                    .Invoke(question);
        }

        private static void SetCorrectContentType()
        {
            var webOperationContext = WebOperationContext.Current;
            if (webOperationContext.IncomingRequest.ContentType != null &&
                webOperationContext.IncomingRequest.ContentType.Contains("/xml"))
            {
                WebOperationContext.Current
                        .OutgoingResponse.Format =
                            WebMessageFormat.Xml;
            }
        }

    }
}
