using _2C2PWebAPI.Models;
using _2C2PWebAPI.Models.Controller;
using _2C2PWebAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2C2PWebAPI.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : BaseController
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPost]
        [Route("getcustomerinfo")]
        public Response<CustomerModel> GetCustomerInfo(CustomerRequestModel request)
        {
            try
            {

                return Response(customerService.GetCustomer(request)).Success();
            }
            catch (Exception ex)
            {
                return Response(new CustomerModel()).Failed(ex.Message);
            }

        }

    }
}
