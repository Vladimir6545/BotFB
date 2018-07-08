using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class BotMessageReceivedRequest
    {
        public BotUser Sender { get; set; }
        public BotUser Recipient { get; set; }
        public string Timestamp { get; set; }
        public BotMessage Message { get; set; }
        public BotPostback Postback { get; set; }
    }
}