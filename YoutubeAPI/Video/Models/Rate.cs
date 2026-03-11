using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.Video.Models
{
    public class Rate
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public Item[] items { get; set; }

        public class Item
        {
            public string videoId { get; set; }
            public string rating { get; set; }
        }

    }
}
