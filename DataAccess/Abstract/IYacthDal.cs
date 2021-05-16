using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IYacthDal : IEntityRepository<Yacth>
    {
        List<YacthDetailDto> GetYacthsDetail(Expression<Func<YacthDetailDto, bool>> filter = null);
        YacthDetailDto GetYacthDetail(int yacthId);
    }
}
