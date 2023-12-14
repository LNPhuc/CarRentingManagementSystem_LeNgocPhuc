using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface ICarInformationService
    {
        List<CarInformation> GetCarInformation();
        CarInformation GetCarInformationByCarId(int carId);
        CarInformation UpdateCarInformation(CarInformation carInformation);
        void AddNewCar(CarInformation carInformation);
    }
}
