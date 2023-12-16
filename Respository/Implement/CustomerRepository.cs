using BussinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Respository.Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Respository.Respository.Implement
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FUCarRentingManagementContext _context;

        public CustomerRepository(FUCarRentingManagementContext context) 
        {
            _context = context;
        }
        public List<Customer> GetCustomer()
        {
            var customer = _context.Set<Customer>().ToList();
            return customer;

        }
        public void DeleteCustomer(int cusid)
        {
            var cus = _context.Set<Customer>().FirstOrDefault(c => c.CustomerId == cusid);
            cus.CustomerStatus = 0; 
        }




        public Customer GetById(int id)
        {
            var customer = _context.Set<Customer>().FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                throw new Exception("ko tim thay");
            }
            return customer;
        }

        

        public Customer UpdateProfile(int id, Customer customer)
        {
            var cus = _context.Set<Customer>().FirstOrDefault(c => c.CustomerId == id);
            if (cus.CustomerName == customer.CustomerName &&

            cus.Email == customer.Email &&
            cus.Telephone == customer.Telephone)
            {
                return null;
            }
            else
            {
                cus.CustomerName = customer.CustomerName;

                
                cus.Telephone = customer.Telephone;

                return cus;
            }          
        }
    }
}
