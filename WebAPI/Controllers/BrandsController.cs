using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                Ok(result.Data);
            }
            BadRequest(result);
            return BadRequest(result.Data);
        }
    }
}
