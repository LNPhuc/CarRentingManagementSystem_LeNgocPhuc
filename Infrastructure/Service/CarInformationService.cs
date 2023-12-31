﻿using BussinessObject.Entity;
using Infrastructure.UnitOfWork;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class CarInformationService : ICarInformationService
    {
        private readonly IUnitofWork _unitOfWork;

        public CarInformationService(IUnitofWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public void AddNewCar(CarInformation carInformation)
        {
            _unitOfWork.CarInformation.AddNewCar(carInformation);
            _unitOfWork.Save();
        }

        public List<CarInformation> GetCarInformation()
        {
            var car = _unitOfWork.CarInformation.GetCarInformation();
            return car;
        }

        public CarInformation GetCarInformationByCarId(int carId)
        {
            var car = _unitOfWork.CarInformation.GetCarInformationByCarId(carId);
            return car;
        }

		public List<CarInformation> GetCarInformationTop3()
		{
			return _unitOfWork.CarInformation.GetCarInformationTop3();
		}

		public CarInformation UpdateCarInformation(CarInformation carInformation)
        {
            var car = _unitOfWork.CarInformation.UpdateCar(carInformation);
            _unitOfWork.Save();
            return car;
        }
    }
}
