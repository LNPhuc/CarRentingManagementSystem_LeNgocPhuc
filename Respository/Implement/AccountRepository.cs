using BussinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Implement
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FUCarRentingManagementContext _context;

        public AccountRepository(FUCarRentingManagementContext context)
        {
            _context = context;
        }

        public bool GetAdminAccount(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
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

        public Customer Login(string email, string password)
        {
            var check = GetAdminAccount(email, password);
            var customer = _context.Set<Customer>().FirstOrDefault(c => c.Email == email && c.Password == password);

            return customer;
        }
    }
}
