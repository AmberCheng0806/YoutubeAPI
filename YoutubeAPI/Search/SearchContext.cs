using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.Search
{
    public class SearchContext
    {
        public HttpUtility HttpUtility { get; set; }
        public string part = "snippet";
        public SearchContext(HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }
        public async Task<Models.Search> GetAllAsync(string keyword, int videoCategoryId, DateTime publishedAfter, string channelId = null, int maxResults = 50, string regionCode = null, string order = "relevance", string type = "video", string videoDuration = "any")
        {
            var query = new Dictionary<string, string>
                {
                    {"part",part },
                    {"q", keyword},
                    {"maxResults",maxResults.ToString()},
                    {"order",order},
                    {"type", type }
                };
            if (channelId != null)
                query.Add("channelId", channelId);
            if (regionCode != null)
                query.Add("regionCode", regionCode);
            if (type.Contains("video"))
            {
                if (publishedAfter != default)
                    query.Add("publishedAfter", publishedAfter.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                if (videoDuration != "any")
                    query.Add("videoDuration", videoDuration);
                if (videoCategoryId > 0)
                    query.Add("videoCategoryId", videoCategoryId.ToString());
            }
            return await HttpUtility.GetAsync<Models.Search>("search", query);
        }
    }
}
