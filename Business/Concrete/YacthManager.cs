using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class YacthManager : IYacthService
    {
        IYacthDal _yacthDal;

        public YacthManager(IYacthDal yacthDal)
        {
            _yacthDal = yacthDal;
        }

        //[CacheAspect]
        [CacheRemoveAspect("IYacthService.Get")]
        public IDataResult<List<Yacth>> GetAll()
        {
            if (DateTime.Now.Hour == 07)
            {
                return new ErrorDataResult<List<Yacth>>(Messages.ErrorYacthListed);
            }

            return new SuccessDataResult<List<Yacth>>(_yacthDal.GetAll(), Messages.YacthListed);
        }

        [CacheAspect]
        public IDataResult<Yacth> GetYacthById(int id)
        {
            Yacth yacth = _yacthDal.Get(c => c.Id == id);
            if (yacth == null)
            {
                return new ErrorDataResult<Yacth>(Messages.GetErrorYacthMessage);
            }
            return new SuccessDataResult<Yacth>(yacth, Messages.YacthGet);

        }

        public IDataResult<List<Yacth>> GetYacthsByBrandId(int brandId)
        {
            List<Yacth> yacths = _yacthDal.GetAll(c => c.BrandId == brandId);
            if (yacths == null)
            {
                return new ErrorDataResult<List<Yacth>>(Messages.GetErrorYacthMessage);
            }
            return new SuccessDataResult<List<Yacth>>(yacths, Messages.GetYacthsByBrandIdMessage);

        }



        public IDataResult<List<YacthDetailDto>> GetYacthsDetail()
        {
            List<YacthDetailDto> yacthDetails = _yacthDal.GetYacthsDetail();
            if (yacthDetails == null)
            {
                return new ErrorDataResult<List<YacthDetailDto>>(Messages.GetErrorYacthMessage);
            }
            return new SuccessDataResult<List<YacthDetailDto>>(yacthDetails, Messages.GetYacthsDetailMessage);
        }


        public IDataResult<List<YacthDetailDto>> GetYacthsByBrandAndColor(int brandId, int colorId)
        {
            List<YacthDetailDto> yacthDetails = _yacthDal.GetYacthsDetail(c => c.BrandId == brandId && c.ColorId == colorId);
            if (yacthDetails == null)
            {
                return new ErrorDataResult<List<YacthDetailDto>>((Messages.GetErrorYacthMessage));
            }
            else
            {
                return new SuccessDataResult<List<YacthDetailDto>>(yacthDetails, Messages.GetErrorYacthMessage);
            }
        }



        [SecuredOperation("admin")]
        [ValidationAspect(typeof(YacthValidator))]
        [CacheRemoveAspect("IYacthService.Get")]
        public IDataResult<Yacth> Add(Yacth yacth)
        {
            _yacthDal.Add(yacth);
            return new SuccessDataResult<Yacth>(yacth, Messages.YacthAdded);
        }

        [SecuredOperation("admin,update")]
        [CacheRemoveAspect("IYacthService.Get")]
        public IResult Update(Yacth yacth)
        {
            if (yacth.DailyPrice > 0)
            {
                _yacthDal.Update(yacth);
                return new SuccessResult(Messages.SuccessYacthUpdated);
            }
            _yacthDal.Update(yacth);
            return new SuccessResult(Messages.DailyPriceInvalid);
        }

        [SecuredOperation("admin,delete")]
        [CacheRemoveAspect("IYacthService.Get")]
        public IResult Delete(Yacth yacth)
        {
            _yacthDal.Delete(yacth);
            return new SuccessResult(Messages.SuccessYacthDelete);
        }

        public IDataResult<List<Yacth>> GetUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Yacth>>(_yacthDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.GetUnitPriceMessage);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Yacth yacth)
        {
            Add(yacth);
            if (yacth.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(yacth);
            return null;
        }

        private IResult CheckIfYacthNameExists(string name)
        {
            var result = _yacthDal.GetAll(c => c.ModelName == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.YacthNameAlreadyExists);
            }
            return new SuccessResult();
        }
        public IDataResult<YacthDetailDto> GetYacthsDetail(int yacthId)
        {
            return new SuccessDataResult<YacthDetailDto>(_yacthDal.GetYacthDetail(yacthId), Messages.GetYacthDetailMessage);
        }
        public IDataResult<List<YacthDetailDto>> GetYacthDetailByBrandId(int brandId)
        {
            return new SuccessDataResult<List<YacthDetailDto>>(_yacthDal.GetYacthsDetail(c => c.BrandId == brandId));
        }
        public IDataResult<List<YacthDetailDto>> GetYacthDetailByColorId(int colorId)
        {
            return new SuccessDataResult<List<YacthDetailDto>>(_yacthDal.GetYacthsDetail(c => c.ColorId == colorId));
        }

        public IDataResult<Yacth> GetYacthMinFindex(int yacthId)
        {
            return new SuccessDataResult<Yacth>(_yacthDal.Get(c => c.Id == yacthId));
        }

        public IDataResult<List<Yacth>> GetYacthsByColorId(int colorId)
        {
            List<Yacth> yacth = _yacthDal.GetAll(c => c.ColorId == colorId);
            if (yacth == null)
            {
                return new ErrorDataResult<List<Yacth>>(Messages.GetErrorYacthMessage);
            }
            return new SuccessDataResult<List<Yacth>>(yacth, Messages.GetYacthsByColorIdMessage);
        }
    }
}
