using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IYacthService
    {
        IDataResult<List<Yacth>> GetAll();
        IDataResult<Yacth> GetYacthById(int id);
        IDataResult<List<Yacth>> GetYacthsByBrandId(int brandId);
        IDataResult<List<Yacth>> GetYacthsByColorId(int colorId);
        IDataResult<List<YacthDetailDto>> GetYacthDetailByColorId(int colorId);
        IDataResult<List<YacthDetailDto>> GetYacthDetailByBrandId(int brandId);
        IDataResult<List<YacthDetailDto>> GetYacthsByBrandAndColor(int brandId, int colorId);
        IDataResult<List<Yacth>> GetUnitPrice(decimal min, decimal max);
        IDataResult<List<YacthDetailDto>> GetYacthsDetail();
        IDataResult<YacthDetailDto> GetYacthsDetail(int yacthId);

        IDataResult<Yacth> Add(Yacth yacth);
        IResult Update(Yacth yacth);
        IResult Delete(Yacth yacth);
        IResult AddTransactionalTest(Yacth yacth);
        IDataResult<Yacth> GetYacthMinFindex(int yacthId);
    }
}
