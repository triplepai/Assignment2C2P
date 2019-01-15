using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PWebAPI.Models
{
    public class CustomerModel
    {
        [JsonProperty("customerID")]
        public int CustomerID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mobile")]
        public int Mobile { get; set; }


        [JsonProperty("transactions")]
        public List<TransactionModel> Transactions = new List<TransactionModel>();
    }
}