﻿using BussinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.IService
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        
    }
}
