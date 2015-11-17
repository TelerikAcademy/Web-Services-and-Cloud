using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tests.Api.Models;
using Tests.Api.ServiceContracts;
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
            this.SetCorrectContentType();

            if (!this.IsModelValid(model))
            {
                throw new WebFaultException(HttpStatusCode.BadRequest);
            }

            var question = new Question();

            question.Text = model.Text;
            question.Category = this.LoadOrCreateCategory(model.Category);
            question.DifficultyLevel = (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), model.Difficulty);
            question.Answers = this.GetAnswersFrom(model);

            this.data.Get<Question>()
                .Add(question);

            this.data.SaveChanges();

            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;

            return QuestionResponseModel.FromQuestion
                    .Compile().Invoke(question);
        }

        public IQueryable<QuestionResponseModel> GetAll()
        {
            this.SetCorrectContentType();

            return this.data.Get<Question>()
                    .All()
                    .Select(QuestionResponseModel.FromQuestion)
                    .AsQueryable();
        }

        public IQueryable<QuestionResponseModel> GetQuestionsForCategory(string category)
        {
            category = category.ToLower();
            return this.GetAll()
                .Where(question => question.Category.ToLower() == category);
        }

        public QuestionResponseModel GetById(string id)
        {
            //validation for id

            this.SetCorrectContentType();

            var question = this.data.Get<Question>()
                     .GetById(int.Parse(id));

            return QuestionResponseModel.FromQuestion
                    .Compile()
                    .Invoke(question);
        }

        private bool IsModelValid(QuestionRequestModel model)
        {
            if (model == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.Category))
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.Difficulty))
            {
                return false;
            }

            if (model.CorrectAnswers == null || model.CorrectAnswers.Count() < 1)
            {
                return false;
            }

            if (model.WrongAnswers == null || model.WrongAnswers.Count() < 1)
            {
                return false;
            }

            return true;
        }

        private ICollection<Answer> GetAnswersFrom(QuestionRequestModel model)
        {
            var answers = new List<Answer>();
            model.CorrectAnswers
                .Select(text => new Answer(text, true))
                .ForEach(answers.Add);

            model.WrongAnswers
                .Select(text => new Answer(text))
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

        private void SetCorrectContentType()
        {
            var operationCtx = WebOperationContext.Current;
            var responseFormat = WebMessageFormat.Json;
            if (!string.IsNullOrEmpty(operationCtx.IncomingRequest.ContentType) &&
                operationCtx.IncomingRequest.ContentType.EndsWith("/xml"))
            {
                responseFormat = WebMessageFormat.Xml;
            }

            operationCtx.OutgoingResponse.Format = responseFormat;
        }
    }
}
