namespace BullsAndCows.PublicRestApi.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using BullsAndCows.Entities;

    public class UserModel
    {
        public static Expression<Func<Entities.User, UserModel>> FromUser
        {
            get
            {
                return user => new UserModel()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }
    }

    public class UserDetailsModel
    {
        public static UserDetailsModel FromUser(User user)
        {
            int wins = (user.Scores.Any()) ? user.Scores.Where(score => score.ScoreType == ScoreType.Won).Count() : 0;
            int losses = (user.Scores.Any()) ? user.Scores.Where(score => score.ScoreType == ScoreType.Lost).Count() : 0;
            return new UserDetailsModel()
            {
                Id = user.Id,
                Username = user.UserName,
                Wins = wins,
                Losses = losses,
                Rank = wins * 100 + losses * 15
            };
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public int Losses { get; set; }

        public int Wins { get; set; }

        public int Rank { get; set; }
    }
}