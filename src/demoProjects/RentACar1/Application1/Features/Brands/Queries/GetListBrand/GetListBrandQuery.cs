using Application1.Features.Brands.Models;
using Application1.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain1.Entities1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Brands.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<BrandListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel> //döndüreceğim tip BrandListModel 
        {

         private readonly  IBrandRepository _brandRepository;
         private readonly  IMapper _mapper;

            public GetListQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
              IPaginate<Brand> brands = await  _brandRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                BrandListModel mappedBandListModel = _mapper.Map<BrandListModel>(brands); //brands ı brand list modele göre maple
                                                                                          
                return mappedBandListModel;
              

            }
        }
    }
}
