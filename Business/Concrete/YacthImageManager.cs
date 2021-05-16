using Business.Abstract;
using Business.Business;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class YacthImageManager : IYacthImageService
    {
        private IYacthImageDal _yacthImageDal;

        public YacthImageManager(IYacthImageDal yacthImageDal)
        {
            _yacthImageDal = yacthImageDal;
        }

        [ValidationAspect(typeof(YacthImageValidator))]
        public IDataResult<YacthImage> Get(int id)
        {
            return new SuccessDataResult<YacthImage>(_yacthImageDal.Get(p => p.Id == id));
        }
        public IDataResult<List<YacthImage>> GetAll()
        {
            return new SuccessDataResult<List<YacthImage>>(_yacthImageDal.GetAll(), Messages.YacthImageListed);
        }
        [ValidationAspect(typeof(YacthImageValidator))]
        public IDataResult<List<YacthImage>> GetImagesByYacthId(int yacthId)
        {
            return new SuccessDataResult<List<YacthImage>>(CheckIfYacthImageNull(yacthId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(YacthImageValidator))]
        public IResult Add(IFormFile file, YacthImage yacthImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(yacthImage.YacthId));
            if (result != null)
            {
                return result;
            }
            yacthImage.ImagePath = FileHelper.Add(file);
            yacthImage.Date = DateTime.Now;
            _yacthImageDal.Add(yacthImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(YacthImageValidator))]
        public IResult Update(IFormFile file, YacthImage yacthImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(yacthImage.YacthId));
            if (result != null)
            {
                return result;
            }
            yacthImage.Date = DateTime.Now;
            string oldPath = Get(yacthImage.Id).Data.ImagePath;
            yacthImage.ImagePath = FileHelper.Update(oldPath, file);
            return new SuccessResult(Messages.YacthImageUpdated);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(YacthImageValidator))]
        public IResult Delete(YacthImage yacthImage)
        {
            IResult result = BusinessRules.Run(YacthImageDelete(yacthImage));
            if (result != null)
            {
                return result;
            }
            _yacthImageDal.Delete(yacthImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimitExceeded(int yacthid)
        {
            var yacthImagecount = _yacthImageDal.GetAll(p => p.YacthId == yacthid).Count;
            if (yacthImagecount >= 5)
            {
                return new ErrorResult(Messages.ImageLimitError);
            }

            return new SuccessResult();
        }
        private List<YacthImage> CheckIfYacthImageNull(int id)
        {
            string path = @"wwwroot\uploads\yacthImages\defaultimage.png";
            var result = _yacthImageDal.GetAll(c => c.YacthId == id).Any();
            if (!result)
            {
                return new List<YacthImage> { new YacthImage { YacthId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _yacthImageDal.GetAll(p => p.YacthId == id);
        }
        private IResult YacthImageDelete(YacthImage yacthImage)
        {
            try
            {
                File.Delete(yacthImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
