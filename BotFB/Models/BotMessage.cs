using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class BotMessage
    {
        public string MId { get; set; }
        public List<MessageAttachment> Attachments { get; set; }
        public long Seq { get; set; }
        public string Text { get; set; }
        public QuickReply QuickReply { get; set; }
    }
}