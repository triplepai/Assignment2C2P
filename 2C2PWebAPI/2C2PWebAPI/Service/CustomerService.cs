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
            
            ValidateModel(request);

            Customer customer = null;
            int customerID = Convert.ToInt32(request.CustomerID);
            if (!string.IsNullOrEmpty(request.CustomerID) && !string.IsNullOrEmpty(request.Email))
            {
                customer = customerRepository.Find(c => c.ID == customerID && c.ContactEmail == request.Email);
            }
            else if (!string.IsNullOrEmpty(request.CustomerID) && string.IsNullOrEmpty(request.Email))
            {
                customer = customerRepository.Find(c => c.ID == customerID);
            }
            else if (string.IsNullOrEmpty(request.CustomerID) && !string.IsNullOrEmpty(request.Email))
            {
                customer = customerRepository.Find(c => c.ContactEmail == request.Email);
            }
            if (customer == null)
            {
                throw new NullReferenceException("Not found");
            }

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
                    Date = transaction.TransactionDate.ToString("dd/MM/yyyy HH:mm"),
                    Amount = transaction.Amount,
                    Currency = transaction.CurrencyCode.ToString(),
                    Status = transaction.Status.ToString()
                });
            }
      
            return result;
        }
        private void ValidateModel(CustomerRequestModel request)
        {
            if (string.IsNullOrEmpty(request.CustomerID) && string.IsNullOrEmpty(request.Email))
            {
                throw new NullReferenceException("No inquiry criteria");
            }
            else if (!string.IsNullOrEmpty(request.CustomerID) && request.CustomerID.Length > 10)
            {
                throw new FormatException("Invalid Customer ID");
            }
            else if (!string.IsNullOrEmpty(request.Email) && request.Email.Length > 25)
            {
                throw new FormatException("Invalude Email");
            }
        }
    }
}