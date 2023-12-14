using BussinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Implement
{
    public class CarInformationRepository : ICarInformationRepository
    {
        private readonly FUCarRentingManagementContext _context;
        private readonly DbSet<CarInformation> _dbSet;
        public CarInformationRepository(FUCarRentingManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<CarInformation>();
        }

        public void AddNewCar(CarInformation carInformation)
        {
            /*carInformation.CarId = _context.Set<CarInformation>().Max(x => x.CarId) + 1;
            CarInformation car = _context.CarInformations.Add(carInformation);*/
            /*int maxCarId = _dbSet.Max(x => (int?)x.CarId) ?? 0;
            carInformation.CarId = maxCarId + 1;*/
             _context.CarInformations.Add(carInformation);
        }

        public List<CarInformation> GetCarInformation()
        {
            var carInformation = _context.Set<CarInformation>().ToList();
            return carInformation;
        }

        public CarInformation GetCarInformationByCarId(int id)
        {
            var car = _context.Set<CarInformation>().Include(c => c.Manufacturer).Include(c => c.Supplier).FirstOrDefault(c => c.CarId == id);
            return car;
        }

        public CarInformation UpdateCar(CarInformation carInformation)
        {
            var car = _context.Set<CarInformation>().FirstOrDefault(c => c.CarId == carInformation.CarId);
            if(car.CarName == carInformation.CarName &&
            car.NumberOfDoors == carInformation.NumberOfDoors &&
            car.SeatingCapacity == carInformation.SeatingCapacity &&
            car.Year == carInformation.Year &&
            car.FuelType == carInformation.FuelType)
            {
                return null;
            }
            else
            {
                car.CarName = carInformation.CarName;
                car.NumberOfDoors = carInformation.NumberOfDoors;
                car.SeatingCapacity = carInformation.SeatingCapacity;
                car.Year = carInformation.Year;
                car.FuelType = carInformation.FuelType;
                return car;
            }          
        }
    }
}
