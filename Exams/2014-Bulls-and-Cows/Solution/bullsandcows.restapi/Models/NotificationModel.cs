using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BullsAndCows.Entities;

namespace BullsAndCows.RestApi.Models
{
    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromNotification
        {
            get
            {
                return notification =>
                    new NotificationModel()
                    {
                        Id = notification.Id,
                        Message = notification.Message,
                        DateCreated = notification.DateCreated,
                        Type = notification.NotificationType.ToString(),
                        State = notification.NotificationState.ToString(),
                        GameId = notification.Game.Id
                    };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }
    }
}