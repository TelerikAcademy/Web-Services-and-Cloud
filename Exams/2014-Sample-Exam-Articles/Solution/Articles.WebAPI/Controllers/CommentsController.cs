namespace Articles.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Articles.Data;
    using Articles.Models;
    using Articles.WebAPI.Models;
    public class CommentsController : BaseApiController
    {
        public CommentsController(IArticlesData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int id, CommentDataModel model)
        {
            var userID = this.User.Identity.GetUserId();
            var comment = new Comment
            {
                ArticleID = id,
                AuthorID = userID,
                Content = model.Content,
                DateCreated = DateTime.Now
            };

            this.data.Comments.Add(comment);
            this.data.SaveChanges();

            return Ok();
        }


    }
}
