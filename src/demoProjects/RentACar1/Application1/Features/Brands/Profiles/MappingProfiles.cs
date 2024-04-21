using Application1.Features.Brands.Commands.CreateBrand;
using Application1.Features.Brands.Dtos;
using Application1.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain1.Entities1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Brands.Profiles
{
    public class MappingProfiles : Profile //auto maper buraya mapleme profilerini yazarız 
    {
        public MappingProfiles() //neyi neye mapliyeceğim 
        {
            CreateMap<Brand ,CreatedBrandDto>().ReverseMap();
            CreateMap<Brand , CreateBrandCommand>().ReverseMap();
            CreateMap<IPaginate<Brand> ,BrandListModel>().ReverseMap();
            CreateMap<Brand ,BrandListDto>().ReverseMap();



        }
    }
}
