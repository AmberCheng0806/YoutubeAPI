using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.PlayList;
using YoutubeAPI.Video;
using YoutubeAPI.Video.Models;

namespace YoutubeAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            YoutubeContext youtube = new YoutubeContext();
            // PlayList playlist = await youtube.playlist.GetAllAsync("UCYOiDSVjnTdspnZjvEK4R5Q");
            YoutubeAPI.PlayList.Models.PlayList playlist2 = await youtube.Playlist.CreateAsync("new", "456", "private");
            //PlayList playlist3 = await youtube.playlist.PutAsync("PLp_06BT3mn3jZVMZV_Jf4KaQiK7ZmsQxp", "my playlist", "123");
            //string playlist4 = await youtube.playlist.DeleteAsync("PLp_06BT3mn3idDoRC-qrmHRP1luqhZIDw");
            //Comment comment = await youtube.comment.GetCommentByVideoIdAsync("3lZYvVRCWO0");
            //Comment comment2 = await youtube.comment.GetCommentByCommentIdAsync("Ugxt-Zxcwf77DM_Jiat4AaABAg");
            //Comment comment3 = await youtube.comment.GetCommentByParentIdAsync("Ugxt-Zxcwf77DM_Jiat4AaABAg");
            //Comment comment4 = await youtube.comment.PostCommentByVideoIdAsync("3lZYvVRCWO0", "UCzlOuU2oqj_FCXEhy3XnvxQ", "❤");
            //Comment comment5 = await youtube.comment.PostCommentByParentIdAsync("Ugwg4FamKvh8Bij-D5N4AaABAg", "❤");
            //Comment comment6 = await youtube.comment.PutCommentByParentIdAsync("Ugwg4FamKvh8Bij-D5N4AaABAg.ARWwUCl9TmUARWye_MQduv", "0");
            //string comment7 = await youtube.comment.DeleteAsync("Ugwg4FamKvh8Bij-D5N4AaABAg.ARWwUCl9TmUARWye_MQduv");
            //Search search = await youtube.search.GetAllAsync("音樂");
            //Video video = await youtube.video.PostAsync("3lZYvVRCWO0", "none");
            //PlayListItem playListItem = await youtube.playListItem.GetAllAsync("PLp_06BT3mn3jZVMZV_Jf4KaQiK7ZmsQxp");
            //PlayListItem2 playListItem2 = await youtube.playListItem.PostAsync("PLp_06BT3mn3jZVMZV_Jf4KaQiK7ZmsQxp", "3lZYvVRCWO0");
            // string playListItem3 = await youtube.playListItem.DeleteAsync("UExwXzA2QlQzbW4zalpWTVpWX0pmNEthUWlLN1ptc1F4cC4wOTA3OTZBNzVEMTUzOTMy");


            //string url = "https://www.googleapis.com/upload/youtube/v3/videos?part=snippet&uploadType=resumable&Content-Type=application/json&x-upload-content-type=application/octet-stream&upload_id=AHVrFxM8C-VyWJACj16ls83Rna7fL3RkXQkj6A6eM-loYC9NCMSlP-bD7I0p9IpRhFv0pvIm5U20ocMGDtWib1nBTX4eeeEqkkQHLID9xU4e3Q";


            //var fileStream = new FileStream(@"C:/Users/user/Downloads/file_example_MP4_640_3MG.mp4", FileMode.Open, FileAccess.Read);
            //StreamContent streamContent = new StreamContent(fileStream);
            //streamContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");

            //MultipartContent multipartContent = new MultipartContent("related", "TEST_BOUNDARY_STRING");

            //var body = new
            //{
            //    snippet = new
            //    {
            //        title = "HELLO"
            //    },
            //    status = new
            //    {
            //        privacyStatus = "private"
            //    }
            //};
            //var json = JsonConvert.SerializeObject(body);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");


            //multipartContent.Add(content);
            //multipartContent.Add(streamContent);


            //PKCE

            //CreateVideo createVideo = await youtube.Video.CreateAsync("123", @"C:/Users/user/Downloads/file_example_MP4_640_3MG.mp4");



            Console.ReadKey();

        }
    }
}
