using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class MessageResponse
    {
        public MessageAttachment Attachment { get; set; }
        public List<QuickReply> QuickReplies { get; set; }
        public string Text { get; set; }
    }
}