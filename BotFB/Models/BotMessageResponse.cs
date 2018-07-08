using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class BotMessageResponse
    {
        public BotUser Recipient { get; set; }
        public MessageResponse Message { get; set; }
    }
}