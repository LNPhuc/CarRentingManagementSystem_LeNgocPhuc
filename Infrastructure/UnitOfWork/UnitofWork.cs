using BussinessObject.Entity;
using Respository.Implement;
using Respository.Interface;
using Respository.Respository.Implement;
using Respository.Respository.Interface;


namespace Infrastructure.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly FUCarRentingManagementContext _context;
        
        public UnitofWork(FUCarRentingManagementContext context)
        {
            _context = context;
            Customer = new CustomerRepository(_context);
            Account = new AccountRepository(_context);
            Transation = new RentingTransationRepository(_context);
            CarInformation = new CarInformationRepository(_context);
        }

        public ICustomerRepository Customer { get; }
        public IAccountRepository Account { get; }
        public IRentingTransationRepository Transation { get; }
        public ICarInformationRepository CarInformation { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
        
    }
}
