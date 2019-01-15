using _2C2PWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PWebAPI.Service.Interface
{
    public interface ICustomerService
    {
        CustomerModel GetCustomer(CustomerRequestModel request);
    }
}