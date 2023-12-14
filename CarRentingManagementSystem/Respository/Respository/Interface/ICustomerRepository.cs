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
        Customer Login(string email, string password);   
        Customer GetById(int id);
        bool GetAdminAccount(string email, string password);
        
    }
}
