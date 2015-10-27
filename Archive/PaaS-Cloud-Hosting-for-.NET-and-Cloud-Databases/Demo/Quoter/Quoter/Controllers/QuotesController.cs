using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Newtonsoft.Json;

namespace Quoter.Controllers
{
    public class QuotesController : ApiController
    {
        [ActionName("one")]
        public Quote GetOne()
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync("http://iheartquotes.com/api/v1/random?format=json").Result;
            var quoteJson = response.Content.ReadAsStringAsync().Result;

            var quoteDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(quoteJson);

            var entityContext = new QuoterEntities();

            var quote = new Quote()
            {
                Content = (string)quoteDict["quote"],
                Source = (string)quoteDict["source"]
            };

            entityContext.Quotes.Add(quote);
            entityContext.SaveChanges();

            return quote;
        }

        [ActionName("all")]
        public IEnumerable<Quote> GetAll()
        {
            var entityContext = new QuoterEntities();

            var allQuotes = entityContext.Quotes.ToList();
             
            return allQuotes;
        }
    }
}
