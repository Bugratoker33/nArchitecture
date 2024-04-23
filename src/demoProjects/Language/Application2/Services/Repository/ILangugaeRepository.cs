using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Domain2.Entities;

namespace Application2.Services.Repository
{
    public interface ILangugaeRepository : IAsyncRepository<Language1>, IRepository<Language1>
    {

    }
}
