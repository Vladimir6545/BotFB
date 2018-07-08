using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class MessageAttachment
    {
        public string Type { get; set; }
        public MessageAttachmentPayLoad Payload { get; set; }
    }
}