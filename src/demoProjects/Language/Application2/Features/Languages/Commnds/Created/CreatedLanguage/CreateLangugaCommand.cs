﻿using Application2.Features.Language.Dtos;
using Application2.Services.Repository;
using AutoMapper;
using Domain2.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application2.Features.Languages.Commnds.Created.CreatedLanguage
{
    public class CreateLangugaCommand:IRequest<CreateLanguageDtos>
    {
        public string Name { get; set; }

        public class CreatedLanguageCommandHandeler : IRequestHandler<CreateLangugaCommand, CreateLanguageDtos>
        {
            private readonly ILangugaeRepository _langugaeRepository;
            private readonly IMapper _mapper;
            private readonly Language1 language1;

            public CreatedLanguageCommandHandeler(ILangugaeRepository langugaeRepository, IMapper mapper)
            {
                _langugaeRepository = langugaeRepository;
                _mapper = mapper;
            }

            public async Task<CreateLanguageDtos> Handle(CreateLangugaCommand request, CancellationToken cancellationToken)
            {
                Language1 language = _mapper.Map<Language1>(request);
                Language1 CreatedLanguage= await _langugaeRepository.AddAsync(language);
                CreateLanguageDtos createLanguageDtos = _mapper.Map<CreateLanguageDtos>(CreatedLanguage);
                return createLanguageDtos;





            }
        }
    }
}
