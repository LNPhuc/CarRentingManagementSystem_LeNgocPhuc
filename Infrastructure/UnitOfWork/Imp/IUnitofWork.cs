using Respository.Interface;
using Respository.Respository.Interface;


namespace Infrastructure.UnitOfWork
{
    public interface IUnitofWork
    {
        ICustomerRepository Customer { get; }
        IAccountRepository Account { get; }
        IRentingTransationRepository Transation { get; }
        ICarInformationRepository CarInformation { get; }
        void Save();
    }
}
