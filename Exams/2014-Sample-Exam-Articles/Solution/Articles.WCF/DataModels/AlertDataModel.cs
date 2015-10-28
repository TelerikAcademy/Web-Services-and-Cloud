using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Articles.WCF.DataModels
{
    public class AlertDataModel
    {
        public static Expression<Func<Alert, AlertDataModel>> FromAlert
        {
            get
            {
                return a => new AlertDataModel
                {
                    Content = a.Content,
                    ID = a.ID
                };
            }
        }

        public int ID { get; set; }

        public string Content { get; set; }
    }
}