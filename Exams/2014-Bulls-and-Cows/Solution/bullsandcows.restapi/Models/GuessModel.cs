using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BullsAndCows.Entities;

namespace BullsAndCows.RestApi.Models
{
    public class GuessModel
    {
        public static Expression<Func<Guess, GuessModel>> FromGuess
        {
            get
            {
                return guess =>
                new GuessModel()
                {
                    Id = guess.Id,
                    UserId = guess.User.Id,
                    Username = guess.User.UserName,
                    GameId = guess.Game.Id,
                    Number = string.Format("{0:0000}", guess.Value),
                    DateMade = guess.DateCreated,
                    CowsCount = guess.CowsCount,
                    BullsCount = guess.BullsCount
                };
            }
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}