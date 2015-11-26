namespace Teleimot.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using Teleimot.Data.Models;
    using Teleimot.Data.Repositories;

    public class RealEstatesService : IRealEstatesService
    {
        private readonly IRepository<RealEstate> realEstates;

        public RealEstatesService(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }
        
        public IQueryable<RealEstate> GetAll(int skip, int take)
        {
            return this.realEstates
                .All()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<RealEstate> GetById(int id)
        {
            return this.realEstates
                .All()
                .Where(r => r.Id == id);
        }

        public int AddNew(RealEstate newRealEstate, string userId)
        {
            newRealEstate.CreatedOn = DateTime.UtcNow;
            newRealEstate.UserId = userId;

            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate.Id;
        }
    }
}
