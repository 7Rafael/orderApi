using orderApi.Repository.ClienteRepositories;
using orderApi.Repository.ChamadoRepositories;
using orderApi.Repository.RoleRepositories;
using orderApi.Repository.SetorRepositories;

namespace orderApi.Repository
{
    public interface IUnityOfWork
    {
        IClienteRepository ClienteRepository { get; }
        IChamadoRepository ChamadoRepository { get; }
        IRoleRepository RoleRepository { get; } 
        ISetorRepository SetorRepository { get; }

        void Commit();
    }
}
