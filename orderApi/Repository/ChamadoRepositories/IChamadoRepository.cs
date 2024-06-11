using orderApi.Model;


namespace orderApi.Repository.ChamadoRepositories
{
    public interface IChamadoRepository : IRepository<Chamado>
    {
        Task<Chamado> CreateAsync(Chamado chamado, int clienteId, int setorId);
    }
}
