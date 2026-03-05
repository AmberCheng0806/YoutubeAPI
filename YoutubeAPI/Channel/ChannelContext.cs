using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Video.Models;

namespace YoutubeAPI.Channel
{
    public class ChannelContext
    {
        public HttpUtility HttpUtility { get; set; }
        public string part = "snippet";
        public ChannelContext(HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }

        public async Task<Models.Channel> GetByChannelIdAsync(string channelId)
        {
            var query = new Dictionary<string, string>
                {
                    {"part",part },
                    {"id", channelId}
                };
            return await HttpUtility.GetAsync<Models.Channel>("channels", query);
        }
    }
}
