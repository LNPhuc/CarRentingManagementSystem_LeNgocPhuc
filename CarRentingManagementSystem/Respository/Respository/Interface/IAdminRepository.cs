using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Respository.Interface
{
    public interface IAdminRepository
    {
        List<Customer> GetCustomer();
        List<CarInformation> GetCarInformation();
    }
}
