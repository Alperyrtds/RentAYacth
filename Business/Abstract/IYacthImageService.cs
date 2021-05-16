using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IYacthImageService
    {
        IResult Add(IFormFile file, YacthImage yacthImage);
        IResult Delete(YacthImage carImage);
        IResult Update(IFormFile file, YacthImage yacthImage);
        IDataResult<YacthImage> Get(int id);
        IDataResult<List<YacthImage>> GetAll();
        IDataResult<List<YacthImage>> GetImagesByYacthId(int yacthId);
    }
}
