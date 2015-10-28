using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BullsAndCows.Entities;
using Microsoft.Ajax.Utilities;

namespace BullsAndCows.RestApi.Models
{
    public class GameModel
    {
        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return game =>
                new GameModel()
                {
                    Id = game.Id,
                    Name = game.Name,
                    Red = game.RedUser.UserName,
                    Blue = (game.BlueUser != null) ? game.BlueUser.UserName : "No blue player yet",
                    GameState = game.State.ToString(),
                    DateCreated = game.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}