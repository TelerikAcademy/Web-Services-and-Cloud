using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posted.Models
{
    public class PostModel
    {
        [BsonId]
        ObjectId Id;

        public string Content { get; set; }
        public string Author { get; set; }
    }
}