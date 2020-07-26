using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenReactNet.Controllers
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            return Ok(await _service.GetCarByIdAsync(id));
        }

        [HttpPost]
        public async Task Post([FromBody] Car newCar)
        {
            await _service.CreateCarAsync(newCar);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Car updatedCar)
        {
            var car = await _service.GetCarByIdAsync(id);

            await _service.UpdateCarAsync(car, updatedCar);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var car = await _service.GetCarByIdAsync(id);
            await _service.DeleteCarAsync(car);
        }
    }
}
