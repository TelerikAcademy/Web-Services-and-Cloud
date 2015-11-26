namespace Teleimot.Web.Api.Models.RealEstates
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;

    public class RealEstateRequestModel : IMapFrom<RealEstate>, IValidatableObject
    {
        [Required]
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string Contact { get; set; }

        [Range(RealEstateConstants.MinConstructionYear, int.MaxValue)]
        public int ConstructionYear { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public RealEstateType Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!this.SellingPrice.HasValue && !this.RentingPrice.HasValue)
            {
                yield return new ValidationResult("Real estate must be marked as available for selling or available for renting!");
            }
        }
    }
}
