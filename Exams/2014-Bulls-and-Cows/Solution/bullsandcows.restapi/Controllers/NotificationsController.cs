namespace BullsAndCows.RestApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using BullsAndCows.Data.UoWs;
    using BullsAndCows.Entities;
    using BullsAndCows.RestApi.Models;
    using Microsoft.AspNet.Identity;
    using BullsAndCows.RestApi.Extensions;
    using BullsAndCows.RestApi.Results;
    using System.Net;
    using System;

    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NotificationsController : BaseApiController
    {
        private const int PageSize = 10;

        public NotificationsController() : base()
        {
        }

        public NotificationsController(IBullsAndCowsData data) : base(data)
        {
        }

        public IHttpActionResult GetPage(int page = 0)
        {
            var userNotifications = this.GetUserNotificationsOrdered()
                                        .Skip(PageSize * page)
                                        .Take(PageSize);
            var userNotificationModels = userNotifications.Select(NotificationModel.FromNotification);
            this.MarkNotificationsAsRead(userNotifications);

            return Ok(userNotificationModels);
        }
        
        [Route("api/notifications/next")]
        public IHttpActionResult GetNextUnreadMessage()
        {
            var notification = this.GetUserNotificationsOrdered()
                                   .Where(notif => notif.NotificationState == NotificationState.Unread)
                                   .FirstOrDefault();

            if (notification == null)
            {
                return new NotModifiedActionResult(this.Request, "No new messages");
            }
            notification.NotificationState = NotificationState.Read;
            this.Data.Notifications.Update(notification);
            this.Data.SaveChanges();

            var notificationModel = (new Notification[] { notification }).AsQueryable()
                                                                         .Select(NotificationModel.FromNotification)
                                                                         .FirstOrDefault();
            return Ok(notificationModel);
        }

        private IQueryable<Notification> GetUserNotificationsOrdered()
        {
            var userId = this.User.Identity.GetUserId();

            var userNotifications = this.Data.Notifications.All()
                                        .Where(notification => notification.User.Id == userId)
                                        .OrderBy(notification => notification.DateCreated);
            return userNotifications;
        }

        private void MarkNotificationsAsRead(IQueryable<Notification> notifications)
        {
            notifications.ForEach(notification => notification.NotificationState = NotificationState.Read);
            this.Data.SaveChanges();
        }
    }
}