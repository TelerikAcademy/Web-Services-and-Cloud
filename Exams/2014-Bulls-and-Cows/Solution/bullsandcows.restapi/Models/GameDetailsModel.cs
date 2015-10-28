using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BullsAndCows.Entities;
using System.Web.Http;

namespace BullsAndCows.RestApi.Models
{
    public class GameDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public int? YourNumber { get; set; }
        
        public IEnumerable<GuessModel> YourGuesses { get; set; }

        public IEnumerable<GuessModel> OpponentGuesses { get; set; }

        public string YourColor { get; set; }

        public string GameState { get; set; }
    }
}