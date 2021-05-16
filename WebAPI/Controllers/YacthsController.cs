using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YacthsController : ControllerBase
    {
        private IYacthService _yacthService;

        public YacthsController(IYacthService yacthService)
        {
            _yacthService = yacthService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Thread.Sleep(3000);
            var result = _yacthService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getyacthbyid")]
        public IActionResult GetByYacthId(int yacthId)
        {
            var result = _yacthService.GetYacthById(yacthId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("brandId")]
        public IActionResult GetYacthsByBrandId(int brandId)
        {
            var result = _yacthService.GetYacthsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Yacth yacth)
        {
            var result = _yacthService.Add(yacth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Yacth yacth)
        {
            var result = _yacthService.Update(yacth);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Yacth yacth)
        {
            var result = _yacthService.Delete(yacth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcolorid")]
        public IActionResult GetYacthsByColorId(int colorId)
        {
            var result = _yacthService.GetYacthsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbrand")]
        public IActionResult GetYacthsByBrand(int brandId)
        {
            var result = _yacthService.GetYacthsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getyacthsbybrandandcolor")]
        public IActionResult GetYacthByBrandAndColor(int brandId, int colorId)
        {
            var result = _yacthService.GetYacthsByBrandAndColor(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getunitprice")]
        public IActionResult GetUnitPrice(decimal min, decimal max)
        {
            var result = _yacthService.GetUnitPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getyacthsdetail")]
        public IActionResult GetYacthDetails()
        {
            var result = _yacthService.GetYacthsDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getyacthdetail")]
        public IActionResult GetYacthDetail(int yacthId)
        {
            var result = _yacthService.GetYacthsDetail(yacthId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getyacthdetailbybrandid")]
        public IActionResult GetYacthDetailByBrandId(int brandId)
        {
            var result = _yacthService.GetYacthDetailByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getyacthdetailbycolorid")]
        public IActionResult GetYacthDetailByColorId(int colorId)
        {
            var result = _yacthService.GetYacthDetailByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getyacthminfindex")]
        public IActionResult GetCarMinFindex(int yacthId)
        {
            var result = _yacthService.GetYacthMinFindex(yacthId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
