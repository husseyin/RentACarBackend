using Business.Abstract;
using Business.Constans.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.OperationResult;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;


        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
                        
            carImage.Path = (FileHelper.Add(formFile)).Remove(0, 59);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);

            return new SuccessResult(SuccessMessage.CarImageAdded);
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count >= 7)
            {
                return new ErrorResult(ErrorMessage.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.Path);
            _carImageDal.Delete(carImage);

            return new SuccessResult(SuccessMessage.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), SuccessMessage.CarImageListed);
        }

        public IDataResult<CarImage> Get(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }                

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.Path = FileHelper.Update(formFile, _carImageDal.Get(c => c.CarId == carImage.CarId).Path);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);

            return new SuccessResult(SuccessMessage.CarImageAdded);
        }

    }
}