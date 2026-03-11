using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Video.Models;

namespace YoutubeAPI.Subscription
{
    public class SubscriptionContext
    {
        public HttpUtility HttpUtility { get; set; }
        public string part = "snippet";
        public SubscriptionContext(HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }

        public async Task<Models.Subscription> GetAsync(string channelId)
        {
            return await HttpUtility.GetAsync<Models.Subscription>("subscriptions", new Dictionary<string, string>()
                {
                    {"part",part },
                    {"forChannelId",channelId},
                    {"mine","true" }
                });
        }

        public async Task<Models.CreateSubscription> SubscriptAsync(string channelId)
        {
            var query = new Dictionary<string, string>
                {
                    {"part",part }
                };
            object body = new
            {
                snippet = new
                {
                    resourceId = new
                    {
                        channelId = channelId,
                    }
                }
            };
            return await HttpUtility.PostAsync<Models.CreateSubscription>("subscriptions", body, query
            );
        }

        public async Task<string> DeleteAsync(string subscriptionId)
        {
            return await HttpUtility.DeleteAsync("subscriptions", new Dictionary<string, string>()
                {
                    {"id",subscriptionId}
                });
        }
    }
}
