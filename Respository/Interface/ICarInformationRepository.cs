using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Interface
{
    public interface ICarInformationRepository
    {
        List<CarInformation> GetCarInformation();
        List<CarInformation> GetCarInformationTop3();
        CarInformation GetCarInformationByCarId(int id);
        CarInformation UpdateCar(CarInformation carInformation);
        void AddNewCar(CarInformation carInformation);
    }
}
