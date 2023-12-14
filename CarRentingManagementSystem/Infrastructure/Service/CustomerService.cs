using BussinessObject.Entity;
using Infrastructure.Service.IService;
using Infrastructure.UnitOfWork;

namespace Infrastructure.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitofWork _unitOfWork;

        public CustomerService()
        {
            _unitOfWork = new UnitofWork(new FUCarRentingManagementContext());
        }

       

        public Customer GetCustomerById(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);
            return customer;
        }
    }
}
