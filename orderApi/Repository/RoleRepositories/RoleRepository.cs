using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;
using orderApi.Repository;
using orderApi.Repository.RoleRepositories;

namespace orderApi.Repository.RoleRepositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }


    }
}
