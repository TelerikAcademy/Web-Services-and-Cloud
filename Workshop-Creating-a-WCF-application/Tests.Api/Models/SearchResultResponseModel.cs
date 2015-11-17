using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Api.Models
{
    [DataContract]
    public class SearchResultResponseModel
    {
        public static Expression<Func<Category, SearchResultResponseModel>> FromCategory
        {
            get
            {
                return category => new SearchResultResponseModel()
                {
                    Type = "Category",
                    Id = category.Id,
                    Text = category.Name
                };
            }
        }

        public static Expression<Func<Question, SearchResultResponseModel>> FromQuestion
        {
            get
            {
                return question => new SearchResultResponseModel()
                {
                    Type = "Question",
                    Id = question.Id,
                    Text = question.Text
                };
            }
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Text { get; private set; }

        [DataMember]
        public string Type { get; private set; }
    }
}
