using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IRentingTransService
    {
        IEnumerable<RentingTransaction> GetRentingHistory(int customerId);
        List<RentingTransaction> GetAllRentingTransaction();
        List<RentingDetail> GetAllRentingDetail();
    }
}
