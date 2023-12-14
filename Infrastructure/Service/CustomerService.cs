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
        public List<Customer> GetCustomer()
        {
            var customer = _unitOfWork.Customer.GetCustomer();
            return customer;
        }
        public void DeleteCustomer(int cusId)
        {
            _unitOfWork.Customer.DeleteCustomer(cusId);
            _unitOfWork.Save();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _unitOfWork.Customer.GetById(id);
            return customer;
        }

        public Customer UpdateProfile(Customer customer)
        {
            var cus = _unitOfWork.Customer.UpdateProfile(customer);
            _unitOfWork.Save();
            return cus;
        }
    }
}
