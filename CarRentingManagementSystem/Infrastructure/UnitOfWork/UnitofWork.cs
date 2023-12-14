using BussinessObject.Entity;
using Respository.Respository.Implement;
using Respository.Respository.Interface;


namespace Infrastructure.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly FUCarRentingManagementContext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAdminRepository _adminRepository;

        public UnitofWork(FUCarRentingManagementContext context)
        {
            _context = context;
            _customerRepository = new CustomerRepository();
            _adminRepository = new AdminRepository();
        }

        public ICustomerRepository CustomerRepository { get { return _customerRepository; } }

        public IAdminRepository AdminRepository { get { return _adminRepository; } }

        public int save()
        {
            return _context.SaveChanges();
        }
    }
}
