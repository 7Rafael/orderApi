using orderApi.Model;

namespace orderApi.Repository.ClienteRepositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> CreateClientWithRoleAsync(Cliente cliente, int roleId);

    }
}
