using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class PayloadElements
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Subtitle { get; set; }
        public List<ResponseButtons> Buttons { get; set; }
        public string ItemUrl { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
    }
}