using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Interface
{
    public interface IRentingTransationRepository
    {
        IEnumerable<RentingTransaction> GetTransactionsHistory(int customerId);
        List<RentingTransaction> GetAllTransaction();
        List<RentingDetail> GetAllTransationDetail();
    }
}
