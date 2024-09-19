using orderApi.Repository.ChamadoRepositories;
using orderApi.Repository.SetorRepositories;

namespace orderApi.Repository
{
    public interface IUnityOfWork
    {
        IChamadoRepository ChamadoRepository { get; }
        ISetorRepository SetorRepository { get; }

        void Commit();
    }
}
