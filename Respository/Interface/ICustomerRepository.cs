using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Respository.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomer();
        Customer GetById(int id);
        Customer UpdateProfile(int id,Customer customer);
        void DeleteCustomer(int id);
    }
}
