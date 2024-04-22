using Application1.Features.Models.Dtos;
using Application1.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain1.Entities1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Models.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model ,ModelListDto>()
                 .ForMember(c=>c.BrandName, opt=>opt.MapFrom(c=>c.Brand.Name))
                 .ReverseMap();
            CreateMap<IPaginate<Model> ,ModelListModel>().ReverseMap(); //brand name okurken modeldeki branda oku gel 

        }
    }
}
