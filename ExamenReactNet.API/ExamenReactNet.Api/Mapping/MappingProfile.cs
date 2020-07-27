using AutoMapper;
using ExamenReactNet.Api.DataTransferObjects;
using ExamenReactNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenReactNet.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.CarId, options => options.MapFrom(c => c.Id))
                .ForMember(dest => dest.OwnerEmail, options => options.MapFrom(c => c.Owner))
                .ReverseMap();

            CreateMap<Car, CarToCreateDto>()
                .ReverseMap();


            CreateMap<Brand, BrandDto>()
                .ForMember(dest => dest.BrandId, options => options.MapFrom(b => b.Id))
                .ForMember(dest => dest.BrandName, options => options.MapFrom(b => b.Name))
                .ReverseMap();
        }
    }
}
