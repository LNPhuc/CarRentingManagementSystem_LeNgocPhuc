using BussinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Implement
{
    public class RentingTransationRepository : IRentingTransationRepository
    {
        private readonly FUCarRentingManagementContext _context;

        public RentingTransationRepository(FUCarRentingManagementContext context)
        {
            _context = context;
        }

        public List<RentingTransaction> GetAllTransaction()
        {
            var lsTrans = _context.Set<RentingTransaction>().Include(c => c.Customer).Include(c => c.RentingDetails).ToList();
            return lsTrans;
        }

        public List<RentingDetail> GetAllTransationDetail()
        {
            var lsTrans = _context.Set<RentingDetail>().Include(c => c.RentingTransaction).Include(c => c.Car).ToList();
            return lsTrans;
        }

        public List<RentingDetail> GetRentingDetailsById(int id)
        {
            var lstrans = _context.Set<RentingDetail>().Include(c => c.Car)
                                    .Include(c => c.Car.Manufacturer)
                                    .Include(c => c.Car.Supplier)
                                    .Where(c => c.RentingTransactionId == id)
                                    .ToList();
            return lstrans;
        }

        public IEnumerable<RentingTransaction> GetTransactionsHistory(int customerId)
        {
            var lsTrans = _context.Set<RentingTransaction>().Include(c => c.Customer).Include(c => c.RentingDetails).Where(c => c.CustomerId == customerId).ToList();
            return lsTrans;
        }
    }
}
