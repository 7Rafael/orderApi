using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;

namespace orderApi.Repository.ChamadoRepositories
{
    public class ChamadoRepository :Repository<Chamado>, IChamadoRepository
    {
        public ChamadoRepository(AppDbContext context) : base(context)
    {
    }

        public async Task<Chamado> CreateAsync(Chamado chamado, int clienteId, int setorId)
        {
            {
                var cliente = await _context.Clientes.FindAsync(clienteId);

                if (cliente == null)
                {
                    // Trate o caso em que a cliente não é encontrada
                    throw new KeyNotFoundException("Cliente not found");
                }

                var setor = await _context.Setores.FindAsync(setorId);

                if (setor == null)
                {
                    // Trate o caso em que a setor não é encontrada
                    throw new KeyNotFoundException("Setor not found");
                }


                chamado.ClienteId = clienteId;
                chamado.Cliente = cliente;
                chamado.SetorId = setorId;
                chamado.Setor = setor;

                _context.Chamados.Add(chamado);
                await _context.SaveChangesAsync();
                return chamado;
            }
        }
    }
}
