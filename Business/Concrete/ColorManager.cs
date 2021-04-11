using Business.Abstract;
using Business.Constans.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.OperationResult;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(SuccessMessage.ColorAdded);

        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(SuccessMessage.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), SuccessMessage.ColorListed);
        }

        public IDataResult<List<Color>> GetColorById(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(SuccessMessage.ColorUpdated);
        }
    }
}
