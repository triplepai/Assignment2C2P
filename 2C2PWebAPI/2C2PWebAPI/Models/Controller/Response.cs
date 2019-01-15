using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PWebAPI.Models.Controller
{
    public abstract class ResponseAbstract<T> where T : ResponseAbstract<T>
    {
        public const int SuccessStatusCode = 200;

        public const string SuccessMessage = "success";

        public const int FailedStatusCode = 400;
        public const string FailedMessage = "failed";
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public T Success()
        {
            this.StatusCode = SuccessStatusCode;
            this.Message = SuccessMessage;

            return (T)this;
        }
        public T Failed()
        {
            this.StatusCode = FailedStatusCode;
            this.Message = FailedMessage;

            return (T)this;
        }
        public T Failed(string message)
        {
            this.StatusCode = FailedStatusCode;
            this.Message = message;

            return (T)this;
        }

        public T Is(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;

            return (T)this;
        }
    }

    public class Response : ResponseAbstract<Response>
    {
        public Response()
        {
        }
    }

    public class Response<T> : ResponseAbstract<Response<T>>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        public Response(T data)
        {
            this.Data = data;
        }
    }
}