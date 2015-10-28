namespace BullsAndCows.RestApi.Controllers
{
    using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BullsAndCows.Data;
using BullsAndCows.Data.UoWs;

    public abstract class BaseApiController : ApiController
    {
        private IBullsAndCowsData data;        

        public BaseApiController()
            :this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {

        }

        public BaseApiController(IBullsAndCowsData bullsAndCowsData)
        {
            this.data = bullsAndCowsData;
        }

        protected IBullsAndCowsData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}