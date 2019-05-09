using System;
using System.Collections.Generic;

namespace Whoever.Common.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException()
           : base("One or more validation failures have occurred.")
        {
            Notifications = new List<KeyValuePair<NotificationType, string>>();
        }

        public NotificationException(string message)
           : base(message)
        {
            Notifications = new List<KeyValuePair<NotificationType, string>>();
        }


        public void AddNotification(KeyValuePair<NotificationType, string> notification)
        {
            Notifications.Add(notification);
        }

        public IList<KeyValuePair<NotificationType, string>> Notifications { get; set; }

        public void AddNotification(NotificationType type, string message)
        {
            AddNotification(new KeyValuePair<NotificationType, string>(type, message));
        }

        public void AddNotifications(IList<KeyValuePair<NotificationType, string>> notifications)
        {
            foreach (var notification in notifications)
            {
                AddNotification(notification);
            }
        }
    }
}
