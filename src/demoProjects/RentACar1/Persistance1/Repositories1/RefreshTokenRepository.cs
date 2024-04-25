using Application1.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistance1.Contexts;

namespace Persistance1.Repositories1
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context) //base efrepository 
                                                                               //Base dbcontexte göre çalışacak 
        {

        }
    }
}
