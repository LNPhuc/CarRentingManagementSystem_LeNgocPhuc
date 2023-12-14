using BussinessObject.Entity;
using Respository.Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Respository.Implement
{
    public class AdminRepository : IAdminRepository
    {
        private readonly FUCarRentingManagementContext _context;

        public AdminRepository()
        {
            _context = new FUCarRentingManagementContext();
        }

        public List<Customer> GetCustomer()
        {
            var customer = _context.Set<Customer>().ToList();
            return customer;
            
        }
        public List<CarInformation> GetCarInformation()
        {
            var carInformation = _context.Set<CarInformation>().ToList();
            return carInformation;
        }
    }
}
