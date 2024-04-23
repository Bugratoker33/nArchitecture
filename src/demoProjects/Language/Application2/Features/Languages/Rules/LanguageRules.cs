using Application2.Services.Repository;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Features.Languages.Rules
{
    public class LanguageBusinessRule
    {
        private readonly ILangugaeRepository _languageRepository;

        public LanguageBusinessRule(ILangugaeRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language1> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }
    }
}
