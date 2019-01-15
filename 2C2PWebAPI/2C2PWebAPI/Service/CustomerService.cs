using _2C2PDB.Model;
using _2C2PDB.Repository.Interface;
using _2C2PWebAPI.Models;
using _2C2PWebAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PWebAPI.Service
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer, Guid> customerRepository;
        private IRepository<Transaction, Guid> transactionRepository;
        public CustomerService(IRepository<Customer, Guid> customerRepository, IRepository<Transaction, Guid> transactionRepository)
        {
            this.customerRepository = customerRepository;
            this.transactionRepository = transactionRepository;
        }
        public CustomerModel GetCustomer(CustomerRequestModel request)
        {
            Customer customer = customerRepository.Find(c => c.ID == request.CustomerID);
            CustomerModel result = new CustomerModel();
            result.CustomerID = customer.ID;
            result.Name = customer.FirstName +" "+ customer.LastName;
            result.Email = customer.ContactEmail;
            result.Mobile = customer.MobileNo;
            foreach (var transaction in customer.Transactions)
            {
                result.Transactions.Add(new TransactionModel
                {
                    ID = transaction.ID,
                    Date = transaction.TransactionDate,
                    Amount = transaction.Amount,
                    Currency = transaction.CurrencyCode.ToString(),
                    Status = transaction.Status.ToString()
                });
            }
            return new CustomerModel();
        }
    }
}