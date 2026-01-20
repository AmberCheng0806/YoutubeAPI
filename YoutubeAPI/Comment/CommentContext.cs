using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.Comment
{
    public class CommentContext
    {
        public HttpUtility HttpUtility { get; set; }
        public string part = "snippet";
        public CommentContext(HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }
        public async Task<Models.Comment> GetCommentByVideoIdAsync(string videoId, int maxResults = 50, string order = "relevance")
        {
            return await HttpUtility.GetAsync<Models.Comment>("commentThreads", new Dictionary<string, string>()
                {
                    {"part",part },
                    {"videoId",videoId },
                    {"maxResults", maxResults.ToString() },
                    {"order",order }
            });
        }

        public async Task<Models.Comment> GetCommentByCommentIdAsync(string id)
        {
            return await HttpUtility.GetAsync<Models.Comment>("commentThreads", new Dictionary<string, string>()
                {
                    {"part",part },
                    {"id",id }
                });
        }
        public async Task<Models.Comment> GetCommentByParentIdAsync(string parentId, int maxResults = 50)
        {
            return await HttpUtility.GetAsync<Models.Comment>("comments", new Dictionary<string, string>()
                {
                    {"part",part },
                    {"parentId",parentId },
                    {"maxResults", maxResults.ToString() }
                });
        }
        public async Task<Models.CreateTopComment> CreateCommentByVideoIdAsync(string videoId, string channelId, string content)
        {
            return await HttpUtility.PostAsync<Models.CreateTopComment>("commentThreads", new
            {
                snippet = new
                {
                    channelId = channelId,
                    topLevelComment = new
                    {
                        snippet = new
                        {
                            textOriginal = content
                        }
                    },
                    videoId = videoId
                }
            }, new Dictionary<string, string>()
                {
                    {"part",part }
                });
        }
        public async Task<Models.CreateReplyComment> CreateCommentByParentIdAsync(string parentId, string content)
        {
            return await HttpUtility.PostAsync<Models.CreateReplyComment>("comments", new
            {
                snippet = new
                {
                    parentId = parentId,
                    textOriginal = content
                }
            }, new Dictionary<string, string>()
                {
                    {"part",part }
                });
        }
        public async Task<Models.UpdateComment> UpdateCommentByParentIdAsync(string id, string content)
        {
            return await HttpUtility.PutAsync<Models.UpdateComment>("comments", new
            {
                id = id,
                snippet = new
                {
                    textOriginal = content
                }
            }, new Dictionary<string, string>()
                {
                    {"part",part }
                });
        }
        public async Task<string> DeleteAsync(string id)
        {
            return await HttpUtility.DeleteAsync("comments", new Dictionary<string, string>()
                {
                    {"id",id }
                });
        }
    }
}
