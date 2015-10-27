using Newtonsoft.Json;
using RandomNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace RandomNews.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        public NewsModel Get(string query)
        {
            HttpClient client = new HttpClient();

            query = query.Replace(" ", "%20"); //not the best URL escaping. Consider using HttpUtility.UrlEncode()

            var response = client.GetAsync("http://api.feedzilla.com/v1/articles/search.json?q=" + query + "&count=1").Result;

            string responseBody = response.Content.ReadAsStringAsync().Result;

            NewsModel newsArticle = ParseFeedzillaArticleJsonToNews(responseBody);

            return newsArticle;
        }

        private static NewsModel ParseFeedzillaArticleJsonToNews(string responseBody)
        {
            var responseBodyAsDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

            var firstArticleString = (responseBodyAsDict["articles"] as Newtonsoft.Json.Linq.JContainer).First.ToString();

            var firstArticleDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(firstArticleString);

            NewsModel newsArticle = new NewsModel() { Title = firstArticleDict["title"], Url = firstArticleDict["url"] };
            return newsArticle;
        }
    }
}
