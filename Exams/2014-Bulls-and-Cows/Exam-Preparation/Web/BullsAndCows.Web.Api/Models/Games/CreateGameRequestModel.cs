namespace BullsAndCows.Web.Api.Models.Games
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class CreateGameRequestModel : BaseGameRequestModel, IValidatableObject
    {
        [Required]
        [MaxLength(GameConstants.GameNameMaxLength)]
        public string Name { get; set; }
    }
}
