﻿using Newtonsoft.Json;

namespace LinePayClassLibrary.Models
{
    /// <summary>
    /// Refund
    /// </summary>
    public class Refund
    {
        [JsonProperty("refundAmount")]
        public int RefundAmount { get; set; }
    }
}
