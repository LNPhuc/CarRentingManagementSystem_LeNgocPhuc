using BussinessObject.Entity;
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

        public CustomerRepository()
        {
            _context = new FUCarRentingManagementContext();
        }

        public bool GetAdminAccount(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("admin.json", true, true)
                .Build();

            // Check if the configuration key exists
            if (config.GetSection("AdminAccount").Exists())
            {
                string emailJson = config["AdminAccount:adminemail"];
                string passwordJson = config["AdminAccount:adminpassword"];

                // Check if both email and password match
                if (emailJson == email && passwordJson == password)
                {
                    return true;
                }
            }

            return false;
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

       

        public Customer Login(string email, string password)
        {
            var check = GetAdminAccount(email, password);
            var customer = _context.Set<Customer>().FirstOrDefault(c => c.Email == email && c.Password == password);

            return customer;
        }
    }
}
