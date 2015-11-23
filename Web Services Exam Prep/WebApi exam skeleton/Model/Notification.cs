using System;

namespace Model
{
    public class Notification
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        NotificationState State { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
