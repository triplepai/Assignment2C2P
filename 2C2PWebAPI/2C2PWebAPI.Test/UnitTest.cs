using System;
using _2C2PDB.Model;
using _2C2PDB.Repository;
using _2C2PWebAPI.Models;
using _2C2PWebAPI.Service;
using _2C2PWebAPI.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2C2PWebAPI.Test
{
    [TestClass]
    public class UnitTest
    {
       
        ICustomerService customerService = new CustomerService(new Repository<Customer, Guid>(new DBContext()), new Repository<Transaction,Guid>(new DBContext()));
        [TestMethod]
        public void TestGetCustomerByID()
        {
            CustomerRequestModel request = new CustomerRequestModel();
            request.CustomerID = "123456";
            CustomerModel result= customerService.GetCustomer(request);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(123456, result.CustomerID);
            Assert.AreEqual("user@domain.com", result.Email);
        }
        [TestMethod]
        public void TestGetCustomerByIDAndEmail()
        {
            CustomerRequestModel request = new CustomerRequestModel();
            request.CustomerID = "123456";
            request.Email = "user@domain.com";
            CustomerModel result = customerService.GetCustomer(request);

            Assert.AreNotEqual(null, result);
        }

        [TestMethod]
        public void TestGetCustomerNotFound()
        {
            CustomerRequestModel request = new CustomerRequestModel();
            request.CustomerID = "1234568";

            Assert.ThrowsException<NullReferenceException>(() => customerService.GetCustomer(request));

        }
        [TestMethod]
        public void TestNoInquiry()
        {
            CustomerRequestModel request = new CustomerRequestModel();

            Assert.ThrowsException<NullReferenceException>(() => customerService.GetCustomer(request));
        }
        [TestMethod]
        public void TestInvalidCustomerID()
        {
            CustomerRequestModel request = new CustomerRequestModel();
            request.CustomerID = "1234567890123";

            Assert.ThrowsException<FormatException>(() => customerService.GetCustomer(request));
        }
        [TestMethod]
        public void TestInvalidEmail()
        {
            CustomerRequestModel request = new CustomerRequestModel();
            request.Email = "user@domain.comuser@domain.comuser@domain.comuser@domain.com";

            Assert.ThrowsException<FormatException>(() => customerService.GetCustomer(request));
        }
    }
}
