using Application2.Features.Languages.Models;
using Application2.Services.Repository;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain2.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery:IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListQueryHandeler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
        {

            private readonly ILangugaeRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandeler(ILangugaeRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }


            public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language1> language = await _languageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                LanguageListModel mappedlanguageListModel = _mapper.Map<LanguageListModel>(language); //brands ı brand list modele göre maple

                return mappedlanguageListModel;
            }
        }
    }
}
