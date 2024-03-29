﻿using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.OperationResult;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetailByCustomerId(int customerId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();        
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);

    }
}
