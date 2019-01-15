using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PWebAPI.Models
{
    public class TransactionModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }


        [JsonProperty("status")]
        public string Status { get; set; }
    }
}