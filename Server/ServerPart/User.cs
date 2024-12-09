using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pratice3Server
{
    public class User
    {
        public DateTime connectionTime;
        public DateTime disconnectTime;
        public int unactiveTime = 0;
        public EndPoint point;
        public int messagesPerHour = 10;
        public bool isConnected = false;
        public User(EndPoint point)
        {
            this.point = point;
        }
        public void MessageSended() => messagesPerHour--;
        public override string ToString()
        {
            return $"Пользователь: {point}" +
                $"\nвремя подключения {connectionTime.Hour}:{connectionTime.Minute}:{connectionTime.Second}";
        }

    }
}
