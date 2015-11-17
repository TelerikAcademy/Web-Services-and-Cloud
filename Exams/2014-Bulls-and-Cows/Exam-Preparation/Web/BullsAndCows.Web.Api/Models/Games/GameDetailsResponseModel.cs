namespace BullsAndCows.Web.Api.Models.Games
{
    using Data.Models;
    using BullsAndCows.Web.Api.Infrastructure.Mappings;
    using AutoMapper;
    using System;
    using System.Linq;
    using Guesses;
    using System.Collections.Generic;

    public class GameDetailsResponseModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public string YourColor { get; set; }

        public IEnumerable<GuessDetailsResponseModel> YourGuesses { get; set; }

        public IEnumerable<GuessDetailsResponseModel> OpponentGuesses { get; set; }

        public string GameState { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            string userId = null;
            configuration.CreateMap<Game, GameDetailsResponseModel>()
                .ForMember(g => g.Blue, opts => opts.MapFrom(g => g.BlueUser == null ? "No blue player yet" : g.BlueUser.Email))
                .ForMember(g => g.Red, opts => opts.MapFrom(g => g.RedUser.Email))
                .ForMember(g => g.GameState, opts => opts.MapFrom(g => g.GameState.ToString()))
                .ForMember(g => g.YourNumber, opts => opts.MapFrom(g => g.BlueUserId == userId ? g.BlueUserNumber : g.RedUserNumber))
                .ForMember(g => g.YourColor, opts => opts.MapFrom(g => g.BlueUserId == userId ? "blue" : "red"))
                .ForMember(g => g.YourGuesses, opts => opts.MapFrom(g => g.Guesses.Where(gs => gs.UserId == userId)))
                .ForMember(g => g.OpponentGuesses, opts => opts.MapFrom(g => g.Guesses.Where(gs => gs.UserId != userId)));
        }
    }
}
