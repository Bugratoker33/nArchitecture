using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application1.Services.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {

    }
}
