using AutoMapper;
using FTech.Application.DataTransferObjects.Cars;
using FTech.Application.DataTransferObjects.Categories;
using FTech.Domain.Entities.Cars;
using FTech.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTech.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Car
            CreateMap<Car, CarForCreationDTO>().ReverseMap();
            CreateMap<Car, CarForResultDTO>().ReverseMap();

            //Category
            CreateMap<Category, CategoryForCreationDTO>().ReverseMap();
            CreateMap<Category, CategoryForResultDTO>().ReverseMap();
        }
    }
}
