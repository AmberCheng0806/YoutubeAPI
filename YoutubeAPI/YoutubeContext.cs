
using HTTP_Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Auth;
using YoutubeAPI.Comment;
using YoutubeAPI.PlayList;
using YoutubeAPI.PlayList.Models;
using YoutubeAPI.PlayListItem;
using YoutubeAPI.Search;
using YoutubeAPI.Video;
using static System.Net.WebRequestMethods;
using Playlist = YoutubeAPI.PlayList.Models.PlayList;
namespace YoutubeAPI
{
    public class YoutubeContext
    {
        public PlaylistContext Playlist { get; set; }
        public PlayListItemContext PlayListItem { get; set; }
        public CommentContext Comment { get; set; }
        public SearchContext Search { get; set; }
        public VideoContext Video { get; set; }
        private HttpUtility httpUtility { get; set; }
        private Token Token = new Token();
        private Interceptor interceptor = new Interceptor();


        public YoutubeContext()
        {
            interceptor.Func = async request =>
            {
                var accessToken = await Token.GetAccessToken();
                request.Headers.Add("Authorization", $"Bearer {accessToken}");
            };
            httpUtility = new HttpUtility(false, interceptor);



            httpUtility.BaseUrl = "https://www.googleapis.com/youtube/v3/";

            Playlist = new PlaylistContext(httpUtility);
            PlayListItem = new PlayListItemContext(httpUtility);
            Comment = new CommentContext(httpUtility);
            Search = new SearchContext(httpUtility);
            Video = new VideoContext(httpUtility);
        }
    }
}
