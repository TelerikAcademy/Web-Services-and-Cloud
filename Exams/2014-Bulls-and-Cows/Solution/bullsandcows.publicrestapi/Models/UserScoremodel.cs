namespace BullsAndCows.PublicRestApi.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using BullsAndCows.Entities;

    public class UserScoreModel
    {
        public static Expression<Func<User, UserScoreModel>> FromUser
        {
            get
            {
                return user => new UserScoreModel()
                {
                    Username = user.UserName,
                    Rank = 100 * ((user.Scores.Any()) ? user.Scores.Where(score => score.ScoreType == ScoreType.Won).Count() : 0) +
                           15 * ((user.Scores.Any()) ? user.Scores.Where(score => score.ScoreType == ScoreType.Lost).Count() : 0)
                };
            }
        }

        public string Username { get; set; }

        public int Rank { get; set; }
    }
}