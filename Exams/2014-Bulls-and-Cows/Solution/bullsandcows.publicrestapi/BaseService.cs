using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BullsAndCows.Data;
using BullsAndCows.Data.UoWs;

namespace BullsAndCows.RestApi.Wcf
{
    public abstract class BaseService
    {
        protected IBullsAndCowsData Data { get; private set; }

        public BaseService():
            this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {

        }

        public BaseService(IBullsAndCowsData data)
        {
            this.Data = data;
        }
    }
}