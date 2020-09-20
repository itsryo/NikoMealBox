﻿using Newtonsoft.Json;

namespace LinePayClassLibrary.Models
{
    /// <summary>
    /// Payment information
    /// </summary>
    public class PayInfo
    {
        /// <summary>
        /// Payment method used
        /// </summary>
        [JsonProperty("method")]
        public PayMethod Method { get; set; }

        /// <summary>
        /// Transaction amount (Amount transacted when the transaction Id was generated)
        /// The final transaction amount when retrieving the original transaction is
        /// sum(info[].payInfo[].amount) – sum(refundList[].refundAmount).
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}