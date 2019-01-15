using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PWebAPI.Models
{
    public class CustomerRequestModel
    {
        [JsonProperty("customerID")]
        public string CustomerID { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}