using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class BotRequest
    {
        public string @Object { get; set; }
        public List<BotEntry> Entry { get; set; }
    }
}