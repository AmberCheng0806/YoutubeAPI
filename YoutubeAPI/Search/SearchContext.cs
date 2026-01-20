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
        public async Task<Models.Search> GetAllAsync(string keyword, string channelId = null, int maxResults = 50, string regionCode = null, string order = "relevance")
        {
            var query = new Dictionary<string, string>
                {
                    {"part",part },
                    {"q", keyword},
                    {"maxResults",maxResults.ToString()},
                    {"order",order}
                };
            if (channelId != null)
                query.Add("channelId", channelId);
            if (regionCode != null)
                query.Add("regionCode", regionCode);
            return await HttpUtility.GetAsync<Models.Search>("search", query);
        }
    }
}
