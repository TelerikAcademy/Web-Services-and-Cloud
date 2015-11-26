namespace Teleimot.Web.Api.Models.RealEstates
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class ListedRealEstateResponseModel : IMapFrom<RealEstate>
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public bool CanBeSold => this.SellingPrice.HasValue;

        public bool CanBeRented => this.RentingPrice.HasValue;
    }
}
