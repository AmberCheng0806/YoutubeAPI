using HTTP_Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.Video
{
    public class VideoContext
    {
        public HttpUtility HttpUtility { get; set; }
        public string part = "snippet";
        public VideoContext(HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }

        public async Task<Models.Video> RateAsync(string id, string rating)
        {
            return await HttpUtility.PostAsync<Models.Video>("videos/rate",
                new Dictionary<string, string>()
            {
                    {"id",id},
                    {"rating",rating},
            }
            );
        }

        public async Task<Models.CreateVideo> CreateAsync(string title, string url, string status = "public")
        {
            //string location = await GetLocation(title);
            //var fileStream = new FileStream(url, FileMode.Open, FileAccess.Read);
            //StreamContent streamContent = new StreamContent(fileStream);
            //streamContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
            //streamContent.Headers.ContentLength = fileStream.Length;
            //streamContent.Headers.Add(
            //"Content-Range",
            //    $"bytes 0-{fileStream.Length - 1}/{fileStream.Length}"
            //);
            //return await HttpUtility.PutAsync<Models.CreateVideo>(location, streamContent);
            var fileStream = new FileStream(url, FileMode.Open, FileAccess.Read);
            StreamContent streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
            MultipartContent multipartContent = new MultipartContent("related", "TEST_BOUNDARY_STRING");
            var body = new
            {
                snippet = new
                {
                    title = title
                },
                status = new
                {
                    privacyStatus = status
                }
            };
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            multipartContent.Add(content);
            multipartContent.Add(streamContent);

            HttpUtility.BaseUrl = "https://www.googleapis.com/upload/youtube/v3/";

            var response = await HttpUtility.PostAsync<Models.CreateVideo>("videos", multipartContent, new Dictionary<string, string>()
            {
                {"uploadType","multipart" },{"part","snippet,status"}
            });
            return response;
        }

        //public async Task<Models.CreateVideo> CreateAsync(string title, Stream stream)
        //{
        //    string location = await GetLocation(title);
        //    StreamContent streamContent = new StreamContent(stream);
        //    streamContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
        //    return await HttpUtility.PutAsync<Models.CreateVideo>(location, streamContent);
        //}

        //private async Task<string> GetLocation(string title)
        //{
        //    var client = new HttpClient();
        //    string url = "https://www.googleapis.com/upload/youtube/v3/videos?part=snippet&uploadType=resumable&Content-Type=application/json&x-upload-content-type=application/octet-stream";
        //    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {HttpUtility.Token}");
        //    var body = new
        //    {
        //        snippet = new
        //        {
        //            title = title
        //        }
        //    };
        //    var json = JsonConvert.SerializeObject(body);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync(url, content);
        //    return response.Headers.Location.ToString();
        //}
    }
}
