using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tests.Api.Models;
using Tests.Api.ServiceContracts;
using Tests.Data;
using Tests.Data.UnitsOfWork;
using Tests.Models;

namespace Tests.Api
{
    public class SearchService : ISearchService
    {
        private IUnitOfWork data;

        public SearchService()
            : this(new EfUnitOfWork(new TestsDbContext()))
        {
        }

        public SearchService(IUnitOfWork uow)
        {
            this.data = uow;
        }

        public IQueryable<SearchResultResponseModel> Search(string pattern)
        {
            return this.SearchCategories(pattern)
                    .Union(this.SearchQuestions(pattern));
        }

        public IQueryable<SearchResultResponseModel> SearchCategories(string pattern)
        {
            pattern = pattern.ToLower();
            return this.data.Get<Category>()
                    .All()
                    .Where(category => category.Name.ToLower().Contains(pattern))
                    .Select(SearchResultResponseModel.FromCategory);
        }

        public IQueryable<SearchResultResponseModel> SearchQuestions(string pattern)
        {
            return this.data.Get<Question>()
                    .All()
                    .Where(question => question.Text.ToLower().Contains(pattern))
                    .Select(SearchResultResponseModel.FromQuestion);
        }
    }
}
