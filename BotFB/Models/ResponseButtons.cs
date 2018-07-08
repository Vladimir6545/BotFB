using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class ResponseButtons
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Payload { get; set; }

        public string Url { get; set; }
        public string WebviewHeightRatio { get; set; }
    }
}