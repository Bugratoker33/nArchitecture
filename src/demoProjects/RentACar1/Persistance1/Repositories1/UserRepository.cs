using Application1.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistance1.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance1.Repositories1
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
