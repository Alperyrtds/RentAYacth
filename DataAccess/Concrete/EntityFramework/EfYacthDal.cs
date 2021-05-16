using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfYacthDal : EfEntityRepositoryBase<Yacth, YacthProjectContext>, IYacthDal
    {
        //getcardetail
        public YacthDetailDto GetYacthDetail(int yacthId)
        {
            using (YacthProjectContext context = new YacthProjectContext())
            {
                var result = from yacth in context.Yacth.Where(c => c.Id == yacthId)
                             join color in context.Colors on yacth.ColorId equals color.Id
                             join brand in context.Brands on yacth.BrandId equals brand.Id
                             select new YacthDetailDto
                             {
                                 Id = yacth.Id,
                                 ModelName = yacth.ModelName,
                                 BrandId = yacth.BrandId,
                                 BrandName = brand.Name,
                                 ColorId = yacth.ColorId,
                                 ColorName = color.Name,
                                 ModelYear = yacth.ModelYear,
                                 DailyPrice = yacth.DailyPrice,
                                 Description = yacth.Description,
                                 MinFindex = yacth.MinFindex,
                                 ImagePath = (from ci in context.YacthImages where ci.YacthId == yacthId select ci.ImagePath).ToList(),
                                 Status = !(context.Rentals.Any(r => r.YacthId == yacth.Id && (r.ReturnDate == null || r.ReturnDate > DateTime.Now))),

                             };
                return result.SingleOrDefault();
            }
        }

        public List<YacthDetailDto> GetYacthsDetail(Expression<Func<YacthDetailDto, bool>> filter = null)
        {
            using (YacthProjectContext context = new YacthProjectContext())
            {
                var result = from c in context.Yacth
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             select new YacthDetailDto
                             {
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ModelName = c.ModelName,
                                 Id = c.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 MinFindex = c.MinFindex,
                                 ImagePath = (from ci in context.YacthImages where ci.YacthId == c.Id select ci.ImagePath).ToList(),
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
