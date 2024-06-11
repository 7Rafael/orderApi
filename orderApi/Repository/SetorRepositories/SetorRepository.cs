using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;
using orderApi.Repository.SetorRepositories;
using System.Data;

namespace orderApi.Repository.SetorRepositories
{
    public class SetorRepository : Repository<Setor>, ISetorRepository
    {
        public SetorRepository(AppDbContext context) : base(context)
        {
        }


    }
}
