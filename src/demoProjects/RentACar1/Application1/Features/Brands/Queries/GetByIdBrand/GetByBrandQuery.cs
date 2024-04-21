using Application1.Features.Brands.Dtos;
using Application1.Features.Brands.Rules;
using Application1.Services.Repositories;
using AutoMapper;
using Domain1.Entities1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Brands.Queries.GetByIdBrand
{
    public class GetByBrandQuery : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByBrandQuery, BrandGetByIdDto> //GetByBrandQuery madeiatere da fırlatırlırsa handeler edilecek 
        {
            private readonly IBrandRepository _bradRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRule _businessRule;

            public GetByIdBrandQueryHandler(IBrandRepository bradRepository, IMapper mapper, BrandBusinessRule brandBusinessRule)
            {
                _bradRepository = bradRepository;
                _mapper = mapper;
                _businessRule = brandBusinessRule;
            }

            public async Task<BrandGetByIdDto> Handle(GetByBrandQuery request, CancellationToken cancellationToken)
            {

                Brand? brand = await _bradRepository.GetAsync(b => b.Id == request.Id);//altı yeşildi ,? koyarak null da gelebilir kabul ediyorum diyoruz 
                _businessRule.BrandShouldExistWhenRequested(brand);
                BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);

                return brandGetByIdDto;

            }
        }
    }
}
