using Core.Persistence.Paging;
using Domain2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application2.Features.Languages.Models
{
    public class LanguageListModel:BasePageableModel
    {
        public IList<Language1> Items { get; set; }
    }
}
