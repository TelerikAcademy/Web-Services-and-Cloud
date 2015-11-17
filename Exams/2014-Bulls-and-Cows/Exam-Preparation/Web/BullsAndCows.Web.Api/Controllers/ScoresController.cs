namespace BullsAndCows.Web.Api.Controllers
{
    using System.Web.Http;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Services.Data.Contracts;
    using Models.HighScore;

    public class ScoresController : ApiController
    {
        private readonly IHighScoreService highScore;

        public ScoresController(IHighScoreService highScore)
        {
            this.highScore = highScore;
        }

        public IHttpActionResult Get()
        {
            var highScoreResult = this.highScore
                .GetLatest()
                .ProjectTo<HighScoreResponseModel>()
                .ToList();

            return this.Ok(highScoreResult);
        }
    }
}
