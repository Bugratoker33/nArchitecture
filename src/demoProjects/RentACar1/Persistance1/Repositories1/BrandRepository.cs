using Application1.Services.Repositories;
using Core.Persistence.Repositories;
using Domain1.Entities1;
using Persistance1.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance1.Repositories1
{
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext context) : base(context) //base efrepository 
                                                                      //Base dbcontexte göre çalışacak 
        {

        }
    }
}
