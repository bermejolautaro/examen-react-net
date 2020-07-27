using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExamenReactNet.Api.DataTransferObjects;
using ExamenReactNet.Api.Validators;
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
        private readonly IMapper _mapper;

        public CarsController(ICarService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Car>, IEnumerable<CarDto>>(await _service.GetAllCarsAsync()));
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> Post([FromBody] CarToCreateDto newCar)
        {
            var validationResult = await new CarToCreateDtoValidator().ValidateAsync(newCar);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _service.CreateCarAsync(_mapper.Map<CarToCreateDto, Car>(newCar));

            if (!result.IsSuccessful)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}