using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.IService
{
    public interface ICustomerService
    {
        List<Customer> GetCustomer();
        Customer GetCustomerById(int id);
        Customer UpdateProfile(int id,Customer customer);
         
        void DeleteCustomer(int cusId);
    }
}
