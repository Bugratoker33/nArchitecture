using Application1.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistance1.Contexts;

namespace Persistance1.Repositories1
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context) //base efrepository 
                                                                      //Base dbcontexte göre çalışacak 
        {

        }
    }
}
