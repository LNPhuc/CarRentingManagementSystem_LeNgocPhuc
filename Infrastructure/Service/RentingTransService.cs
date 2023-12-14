using BussinessObject.Entity;
using Infrastructure.IService;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class RentingTransService : IRentingTransService
    {
        private readonly IUnitofWork _unitOfWork;

        public RentingTransService(IUnitofWork unitOfWork)
        {
            _unitOfWork = new UnitofWork(new FUCarRentingManagementContext());
        }

        public List<RentingDetail> GetAllRentingDetail()
        {
            return _unitOfWork.Transation.GetAllTransationDetail();
        }

        public List<RentingTransaction> GetAllRentingTransaction()
        {
            return _unitOfWork.Transation.GetAllTransaction();
        }

        public IEnumerable<RentingTransaction> GetRentingHistory(int customerId)
        {
            var lsRenting = _unitOfWork.Transation.GetTransactionsHistory(customerId);
            return lsRenting;
        }
    }
}
