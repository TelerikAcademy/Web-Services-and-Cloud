namespace BullsAndCows.Web.Api.Models.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Common.Constants;

    public class BaseGameRequestModel : IValidatableObject
    {
        [Required]
        [MinLength(GameConstants.GuessNumberLength)]
        [MaxLength(GameConstants.GuessNumberLength)]
        public string Number { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var digits = this
                .Number
                .Where(char.IsDigit)
                .Distinct()
                .ToList();

            if (digits.Count() != GameConstants.GuessNumberLength)
            {
                yield return new ValidationResult("Number's digits must be distinct!");
            }
        }
    }
}
