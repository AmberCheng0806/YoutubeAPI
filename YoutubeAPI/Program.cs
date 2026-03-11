using CredentialManagement;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Auth;
using YoutubeAPI.Auth.Models;
using YoutubeAPI.PlayList;
using YoutubeAPI.Video;
using YoutubeAPI.Video.Models;

namespace YoutubeAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Token token = new Token();
            var result = await token.GetAccessToken();


            Console.ReadKey();

        }
    }
}
