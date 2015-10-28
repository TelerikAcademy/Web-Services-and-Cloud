namespace BullsAndCows.PublicRestApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;

    using BullsAndCows.Entities;
    using BullsAndCows.RestApi.Wcf;
    using BullsAndCows.PublicRestApi.Models;
    using BullsAndCows.Data.UoWs;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ScoresService : BaseService, IScoresService
    {
        public ScoresService()
            : base()
        {

        }

        public ScoresService(IBullsAndCowsData data)
            : base(data)
        {

        }

        public IEnumerable<UserScoreModel> GetAll()
        {
            var scores = this.GetScores()
                .Take(10);
            return scores;
        }

        private IEnumerable<UserScoreModel> GetScores()
        {
            var scores = this.Data.Users.All()
                .Select(UserScoreModel.FromUser)
                .OrderByDescending(score => score.Rank);

            return scores;
        }
    }
}
