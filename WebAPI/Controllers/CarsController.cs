using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService carManager;

        public CarsController(ICarService carManager)
        {
            this.carManager = carManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = carManager.GetAll();
            if (result.Success)
            {
                Ok(result.Data);
            }
                BadRequest(result);

            return BadRequest(result.Data);
        }
    }
}
