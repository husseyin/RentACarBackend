using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.OperationResult;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile formFile, CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int imageId);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
    }
}