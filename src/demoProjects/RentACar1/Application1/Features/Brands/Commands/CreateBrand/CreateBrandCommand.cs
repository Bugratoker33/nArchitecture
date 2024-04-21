using Application1.Features.Brands.Dtos;
using Application1.Features.Brands.Rules;
using Application1.Services.Repositories;
using AutoMapper;
using Domain1.Entities1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand :IRequest<CreatedBrandDto>//bu işlem sonucunda döndüreceğimiz Dto 
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
          private readonly  IBrandRepository _brandrepository;
          private readonly  IMapper _mapper;
            private readonly BrandBusinessRule _brandBusinessRule;
          

            public CreateBrandCommandHandler(IBrandRepository brandrepository, IMapper mapper ,BrandBusinessRule brandBusinessRule)
            {
                _brandrepository = brandrepository;
                _mapper = mapper;
                _brandBusinessRule = brandBusinessRule;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
              await _brandBusinessRule.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                Brand mappedBrand = _mapper.Map<Brand>(request); //gelen requesti brand nesnesibne çevir
                Brand createdBrand = await _brandrepository.AddAsync(mappedBrand); //repositoriyi kulanarak ekleme işlemini gerçekleştirme //
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);//veri tabanından geleni dto çevirmemiz lazım 
               
                return createdBrandDto;

            }
        }

    }
}
