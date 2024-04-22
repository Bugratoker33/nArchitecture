using Application1.Services.Repositories;
using Core.Persistence.Repositories;
using Domain1.Entities1;
using Persistance1.Contexts;

namespace Persistance1.Repositories1
{
    public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext context) : base(context) //base efrepository 
                                                                      //Base dbcontexte göre çalışacak 
        {

        }
    }
}
