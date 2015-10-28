using DataLayer;
using Forum.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Forum.WebAPI.Attributes;

namespace Forum.WebAPI.Controllers
{
    public class ThreadsController : BaseApiController
    {

        [HttpGet]
        public IQueryable<ThreadModel> GetAll()
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                return new List<ThreadModel>().AsQueryable();
            });
        }

        //[HttpGet]
        //public IQueryable<ThreadModel> GetAll(
        //    [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        //{
        //    var responseMsg = this.PerformOperationAndHandleExceptions(() =>
        //    {
        //        var context = new ForumContext();

        //        var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
        //        if (user == null)
        //        {
        //            throw new InvalidOperationException("Invalid username or password");
        //        }

        //        var threadEntities = context.Threads;
        //        var models =
        //            (from threadEntity in threadEntities
        //             select new ThreadModel()
        //             {
        //                 Id = threadEntity.Id,
        //                 Title = threadEntity.Title,
        //                 DateCreated = threadEntity.DateCreated,
        //                 Content = threadEntity.Content,
        //                 CreatedBy = threadEntity.User.Nickname,
        //                 Posts = (from postEntity in threadEntity.Posts
        //                          select new PostModel()
        //                          {
        //                              Content = postEntity.Content,
        //                              PostDate = postEntity.PostDate,
        //                              PostedBy = postEntity.User.Nickname
        //                          }),
        //                 Categories = (from categoryEntity in threadEntity.Categories
        //                               select categoryEntity.Name)
        //             });
        //        return models.OrderByDescending(thr => thr.DateCreated);
        //    });

        //    return responseMsg;
        //}

        ////api/threads?sessionKey=.......&page=5&count=3
        //public IQueryable<ThreadModel> GetPage(int page, int count,
        //   string sessionKey)
        //{
        //    var models = this.GetAll(sessionKey)
        //        .Skip(page * count)
        //        .Take(count);
        //    return models;
        //}

        //public IQueryable<ThreadModel> GetByCategory(string category,
        //    [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        //{
        //    var models = this.GetAll(sessionKey)
        //        .Where(thr => thr.Categories.Any(c => c == category));
        //    return models;
        //}

        //[ActionName("posts")]
        //public IQueryable<PostModel> GetPosts(int threadId,
        //    [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        //{
        //    //var context = new ForumContext();

        //    //var postEntities = context.Threads.FirstOrDefault(thr => thr.Id == threadId).Posts;
        //    ////parsing to PostModel

        //    PostModel[] models = { new PostModel(){
        //        Content="First",
        //        PostDate= DateTime.Now,
        //        PostedBy="Bai Gosho",
        //        Rating = "5/5"
        //    }};
        //    return models.AsQueryable();
        //}
    }
}
