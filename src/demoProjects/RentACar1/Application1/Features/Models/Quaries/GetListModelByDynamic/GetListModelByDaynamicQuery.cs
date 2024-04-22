using Application1.Features.Models.Models;
using Application1.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain1.Entities1;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Models.Quaries.GetListModelByDynamic
{
    public class GetListModelByDynamicQuery : IRequest<ModelListModel>
    {
        public Dynamic Dynamic { get; set; } //dinamik sorgu istiyoruz
        public PageRequest PageRequest { get; set; }

        public class GetListByDynamicQueryHanmdler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            private readonly IMapper _mapper;
            private readonly IModelRepository _modelRepository;

            public GetListByDynamicQueryHanmdler(IMapper mapper, IModelRepository repository)
            {
                _mapper = mapper;
                _modelRepository = repository;
            }

            public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
            {                  //car model
                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(dynamic:request.Dynamic,include:
                                                m => m.Include(c => c.Brand),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );

                //data model 
                ModelListModel mappedModels = _mapper.Map<ModelListModel>(models);
                return mappedModels;
            }
        }
    }
}
