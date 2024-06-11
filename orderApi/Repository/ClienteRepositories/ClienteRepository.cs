using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;

namespace orderApi.Repository.ClienteRepositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Cliente> CreateClientWithRoleAsync(Cliente cliente, int roleId)
        {
            {
                var role = await _context.Roles.FindAsync(roleId);
                if (role == null)
                {
                    // Trate o caso em que a role não é encontrada
                    throw new KeyNotFoundException("Role not found");
                }

                cliente.RoleId = roleId;
                cliente.Role = role;

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
        }
    }
}
