using FirebaseAdmin.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public static class SendNotificationService
    {

        public static async Task<int> SendNotificationAsync(List<string> deviceTokens, string title, string body)
        {
            BatchResponse response = null;
            if (deviceTokens.Count() > 0)
            {
                var content = new MulticastMessage
                {
                    Tokens = deviceTokens,
                    Data = new Dictionary<string, string>()
                    {
                        { "title", title },
                        { "text", body },
                    }
                };

                response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(content);
                if (response.FailureCount > 0)
                {
                    var failedTokens = new List<string>();
                    for (var i = 0; i < response.Responses.Count; i++)
                    {
                        if (!response.Responses[i].IsSuccess)
                        {
                            failedTokens.Add(deviceTokens[i]);
                        }
                    }
                }
            }

            return response.SuccessCount;
        }

    }
}
