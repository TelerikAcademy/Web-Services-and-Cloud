using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using BullsAndCows.Data.UoWs;
using BullsAndCows.Entities;
using BullsAndCows.RestApi.Models;
using Microsoft.AspNet.Identity;

namespace BullsAndCows.RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ScoresController : BaseApiController
    {
        public ScoresController()
            : base()
        {
        }

        public ScoresController(IBullsAndCowsData data)
            : base(data)
        {
        }
        public IHttpActionResult GetAll()
        {
            var scores = this.GetScores()
                .Take(10);
            return Ok(scores);
        }

        private IQueryable<UserScoreModel> GetScores()
        {
            var scores = this.Data.Users.All()
                .Select(UserScoreModel.FromUser)
                .OrderByDescending(score => score.Rank);

            return scores;
        }

    }
}