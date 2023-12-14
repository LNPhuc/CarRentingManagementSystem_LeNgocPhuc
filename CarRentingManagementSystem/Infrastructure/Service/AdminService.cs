using BussinessObject.Entity;
using Infrastructure.Service.IService;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class AdminService : IAdminService
    {
        private readonly IUnitofWork _unitOfWork;

        public AdminService()
        {
            _unitOfWork = new UnitofWork(new FUCarRentingManagementContext());
        }

        public List<Customer> GetCustomer()
        {
            var customer = _unitOfWork.AdminRepository.GetCustomer();
            return customer;
        }
        public List<CarInformation> GetCarInformation()
        {
            var car = _unitOfWork.AdminRepository.GetCarInformation();
            return car;
        }
    }
}
