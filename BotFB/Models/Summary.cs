using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFB.Models
{
    public class Summary
    {
        public decimal? Subtotal { get; set; }
        public decimal? ShippingCost { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal TotalCost { get; set; }
    }
}