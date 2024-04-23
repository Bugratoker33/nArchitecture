using Application2.Services.Repository;
using Core.Persistence.Repositories;
using Domain2.Entities;
using Persistance2.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance2.Repositories
{
    public class LangugaeRepositories : EfRepositoryBase<Language1, BaseDbContext>, ILangugaeRepository
    {

        public LangugaeRepositories(BaseDbContext context) : base(context) //base efrepository 
                                                                           //Base dbcontexte göre çalışacak 
        {

        }
    }
}

