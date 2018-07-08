using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class QuickReply
    {
        public string ContentType { get; set; }
        public string Title { get; set; }
        public string Payload { get; set; }
    }
}