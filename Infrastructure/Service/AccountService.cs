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
    public class AccountService : IAccountService
    {
        private readonly IUnitofWork _unitOfWork;

        public AccountService()
        {
            _unitOfWork = new UnitofWork(new FUCarRentingManagementContext());
        }

        public bool GetAdminAccount(string email, string password)
        {
            return _unitOfWork.Account.GetAdminAccount(email, password);
        }

        public Customer Login(string email, string password)
        {
            return _unitOfWork.Account.Login(email, password);
        }
    }
}
