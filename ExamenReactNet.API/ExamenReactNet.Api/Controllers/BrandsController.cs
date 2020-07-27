using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExamenReactNet.Api.DataTransferObjects;
using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenReactNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<Brand>, IEnumerable<BrandDto>>(await _service.GetAllBrandsAsync()));
        }
    }
}
