using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamenReactNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return Ok(await _service.GetAllCarsAsync());
        }

        [HttpPost]
        public async Task Post([FromBody] Car newCar)
        {
            await _service.CreateCarAsync(newCar);
        }
    }
}