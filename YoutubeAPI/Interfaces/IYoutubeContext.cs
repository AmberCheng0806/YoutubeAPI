using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Channel;
using YoutubeAPI.Comment;
using YoutubeAPI.PlayList;
using YoutubeAPI.PlayListItem;
using YoutubeAPI.Search;
using YoutubeAPI.Subscription;
using YoutubeAPI.Video;

namespace YoutubeAPI.Interfaces
{
    public interface IYoutubeContext
    {
        PlaylistContext Playlist { get; set; }
        PlayListItemContext PlayListItem { get; set; }
        CommentContext Comment { get; set; }
        SearchContext Search { get; set; }
        VideoContext Video { get; set; }
        ChannelContext Channel { get; set; }
        SubscriptionContext Subscription { get; set; }
    }
}
