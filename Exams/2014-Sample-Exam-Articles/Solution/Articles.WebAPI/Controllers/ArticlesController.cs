
namespace Articles.WebAPI.Controllers
{
    using Articles.Data;
    using Articles.Models;
    using Articles.WebAPI.DataModels;
    using Articles.WebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;
    public class ArticlesController : BaseApiController
    {
        const int defaultPageSize = 10;

        public ArticlesController(IArticlesData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(ArticleDataModel model)
        {
            var userID = this.User.Identity.GetUserId();
            var tags = GetTags(model);
            var category = GetCategory(model.Category);

            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                DateCreated = DateTime.Now,
                CategoryID = category.ID,
                AuthorID = userID,
                Tags = tags,
            };
            this.data.Articles.Add(article);
            this.data.SaveChanges();

            model.ID = article.ID;
            model.DateCreated = article.DateCreated;
            model.Tags = article.Tags.AsQueryable()
                .Select(TagDataModel.FromTag).ToArray();

            return Ok(model);
        }

        private Category GetCategory(string modelCategory)
        {
            var category = this.data.Categories.All()
                .FirstOrDefault(c => c.Name == modelCategory);
            if (category == null)
            {
                category = new Category { Name = modelCategory };
                this.data.Categories.Add(category);
            }

            return category;
        }

        private ICollection<Tag> GetTags(ArticleDataModel model)
        {
            var titletgas = model.Title.Split(' ');
            var allTags = new HashSet<string>(titletgas);

            foreach (var modelTag in model.Tags)
            {
                allTags.Add(modelTag.Name);
            }

            var articleTags = new HashSet<Tag>();
            foreach (var tagName in allTags)
            {
                var tag = this.data.Tags.All()
                .FirstOrDefault(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag { Name = tagName };
                    this.data.Tags.Add(tag);
                }

                articleTags.Add(tag);
            }

            return articleTags;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(null, 0);
        }

        [HttpGet]
        public IHttpActionResult GetByID(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            var articleModel = new ArticleDetailsDataModel(article);
            return Ok(articleModel);
        }

        [HttpGet]
        public IHttpActionResult Get(string category)
        {
            return Get(category, 0);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            return Get(null, page);
        }

        [HttpGet]
        public IHttpActionResult Get(string category, int page)
        {
            var articles = GetAllSortedByDate()
                .Where(a => category != null ? a.Category == category : true)
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);

            return Ok(articles);
        }

        private IEnumerable<ArticleDataModel> GetAllSortedByDate()
        {
            return this.data.Articles.All()
                .OrderByDescending(a => a.DateCreated)
                .Select(ArticleDataModel.FromArticle);
        }
    }
}
