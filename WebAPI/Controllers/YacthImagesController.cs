using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YacthImagesController : ControllerBase
    {
        private IYacthImageService _yacthImageService;

        public YacthImagesController(IYacthImageService yacthImageService)
        {
            _yacthImageService = yacthImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _yacthImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbyyacthid")]
        public IActionResult GetImagesById(int yacthId)
        {
            var result = _yacthImageService.GetImagesByYacthId(yacthId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _yacthImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] YacthImage yacthImage)
        {
            var result = _yacthImageService.Add(file, yacthImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] YacthImage yacthImage, [FromForm(Name = ("Image"))] IFormFile file)
        {
            var result = _yacthImageService.Update(file, yacthImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {

            var carImage = _yacthImageService.Get(Id).Data;

            var result = _yacthImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
