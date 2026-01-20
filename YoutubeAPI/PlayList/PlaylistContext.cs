using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.PlayList
{
    public class PlaylistContext
    {
        public HttpUtility HttpUtility { get; set; }
        public string part = "snippet";
        public PlaylistContext(HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }
        public async Task<PlayList.Models.PlayList> GetAllAsync(string channelId)
        {
            return await HttpUtility.GetAsync<PlayList.Models.PlayList>("playlists", new Dictionary<string, string>()
                {
                    {"part",part },
                    {"channelId",channelId }
                });
        }

        public async Task<PlayList.Models.PlayList> CreateAsync(string title, string description = null, string status = "public")
        {
            return await HttpUtility.PostAsync<PlayList.Models.PlayList>("playlists", new
            {
                snippet = new
                {
                    title = title,
                    description = description
                },
                status = new
                {
                    privacyStatus = status
                }
            },
                new Dictionary<string, string>()
            {
                    {"part",part+",status"  }
            }
            );
        }

        public async Task<PlayList.Models.PlayList> UpdateAsync(string id, string title, string description = null, string status = "public")
        {
            return await HttpUtility.PutAsync<PlayList.Models.PlayList>("playlists", new
            {
                id = id,
                snippet = new
                {
                    title = title,
                    description = description
                },
                status = new
                {
                    privacyStatus = status
                }
            },
                new Dictionary<string, string>()
            {
                    {"part",part+",status"  }
            }
            );
        }

        public async Task<string> DeleteAsync(string id)
        {
            return await HttpUtility.DeleteAsync("playlists", new Dictionary<string, string>()
                {
                    {"id",id }
                });
        }
    }
}
