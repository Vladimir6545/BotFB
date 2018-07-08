using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class BotEntry
    {
        public string Id { get; set; }
        public long Time { get; set; }
        public List<BotMessageReceivedRequest> Messaging { get; set; }
    }
}