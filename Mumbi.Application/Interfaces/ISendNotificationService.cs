using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface ISendNotificationService
    {
        Task<bool> SendPushNotification(string[] deviceTokens, string title, string body, object data);
    }
}
