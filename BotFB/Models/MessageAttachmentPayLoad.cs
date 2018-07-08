using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class MessageAttachmentPayLoad
    {
        public string Url { get; set; }
        public string TemplateType { get; set; }
        public string TopElementStyle { get; set; }
        public List<PayloadElements> Elements { get; set; }
        public List<ResponseButtons> Buttons { get; set; }
        public string RecipientName { get; set; }
        public string OrderNumber { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderUrl { get; set; }
        public string Timestamp { get; set; }
        public Address Address { get; set; }
        public Summary Summary { get; set; }
    }
}