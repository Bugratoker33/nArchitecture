using Application2.Features.Language.Dtos;
using Application2.Features.Languages.Commnds.Created.CreatedLanguage;
using AutoMapper;
using Core.Persistence.Paging;
using Domain2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Features.Languages.Profiles
{
    public class MappingProfiles : Profile //auto maper buraya mapleme profilerini yazarız 
    {
        public MappingProfiles() //neyi neye mapliyeceğim 
        {
            CreateMap<Language1 ,CreateLanguageDtos>().ReverseMap();
            CreateMap<Language1,CreateLangugaCommand>().ReverseMap();

            //CreateMap<Brand, CreatedBrandDto>().ReverseMap();
            //CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            //CreateMap<Brand, DeleteBrandDto>().ReverseMap();
            //CreateMap<Brand, DeleteBrandCommand>().ReverseMap();

            //CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
            //CreateMap<Brand, BrandListDto>().ReverseMap();
            //CreateMap<Brand, BrandGetByIdDto>().ReverseMap();





        }
    }
}
