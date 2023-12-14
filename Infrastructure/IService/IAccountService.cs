using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IAccountService
    {
        Customer Login(string email, string password);
        bool GetAdminAccount(string email, string password);

    }
}
