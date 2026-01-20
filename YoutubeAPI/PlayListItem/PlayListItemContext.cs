using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.PlayListItem
{
    public class PlayListItemContext
    {
        public HttpUtility HttpUtility { get; set; }
        public string part = "snippet";
        public PlayListItemContext(HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }
        public async Task<Models.PlayListItem> GetAllAsync(string playListId, int maxResults = 50)
        {
            return await HttpUtility.GetAsync<Models.PlayListItem>("playlistItems", new Dictionary<string, string>()
                {
                    {"part",part },
                    {"playlistId",playListId },
                    {"maxResults", maxResults.ToString()}
                });
        }
        public async Task<Models.CreatePlayListItem> CreateAsync(string playlistId, string videoId)
        {
            return await HttpUtility.PostAsync<Models.CreatePlayListItem>("playlistItems", new
            {
                snippet = new
                {
                    playlistId = playlistId,
                    resourceId = new
                    {
                        kind = "youtube#video",
                        videoId = videoId
                    }
                }
            },
                new Dictionary<string, string>()
            {
                    {"part",part }
            }
            );
        }
        public async Task<string> DeleteAsync(string id)
        {
            return await HttpUtility.DeleteAsync("playlistItems", new Dictionary<string, string>()
                {
                    {"id",id }
                });
        }
    }
}
