using _2C2PWebAPI.Models.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace _2C2PWebAPI.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected Response<T> Response<T>(T data)
        {
            return new Response<T>(data);
        }

        protected Response Response()
        {
            return new Response();
        }
    }
}