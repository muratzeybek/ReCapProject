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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                Ok(result.Data);
            }
            BadRequest(result);
            return BadRequest(result.Data);
        }
    }
}
