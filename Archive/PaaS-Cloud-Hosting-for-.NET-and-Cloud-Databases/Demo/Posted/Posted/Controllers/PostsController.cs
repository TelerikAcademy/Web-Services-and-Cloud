using Posted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver.Linq;
using System.Configuration;

namespace Posted.Controllers
{
    public class PostsController : ApiController
    {
        public static readonly string mongoUrl = ConfigurationManager.AppSettings["MONGOLAB_URI"];//"mongodb://appharbor_9b90a2b5-eaea-4e1b-808a-dc8cb6c96fd6:fh7dqrf7fqukmdsebbhhjepes4@ds039088.mongolab.com:39088/appharbor_9b90a2b5-eaea-4e1b-808a-dc8cb6c96fd6";
        public static readonly string mongoDatabase = "appharbor_9b90a2b5-eaea-4e1b-808a-dc8cb6c96fd6";

        public IEnumerable<PostModel> Get()
        {
            var db = ConnectToDatabase();

            var posts = db.GetCollection("posts");

            var query =
                from post in posts.AsQueryable<PostModel>()
                select post;

            return query.ToList();
        }

        private static MongoDB.Driver.MongoDatabase ConnectToDatabase()
        {
            MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient(mongoUrl);

            var server = client.GetServer();

            var db = server.GetDatabase(mongoDatabase);
            return db;
        }

        public void Post([FromBody] PostModel post)
        {
            var db = ConnectToDatabase();

            var posts = db.GetCollection("posts");

            posts.Insert(post);
        }
    }
}
