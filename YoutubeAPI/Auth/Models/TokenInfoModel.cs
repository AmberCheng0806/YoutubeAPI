using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.Auth.Models
{
    public class TokenInfoModel
    {


        public string aud { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public string access_type { get; set; }


    }
}
