using Respository.Respository.Interface;


namespace Infrastructure.UnitOfWork
{
    public interface IUnitofWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IAdminRepository AdminRepository { get; }
    }
}
