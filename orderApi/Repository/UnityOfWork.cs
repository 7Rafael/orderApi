using orderApi.Context;
using orderApi.Repository.ChamadoRepositories;
using orderApi.Repository.ClienteRepositories;
using orderApi.Repository.RoleRepositories;
using orderApi.Repository.SetorRepositories;

namespace orderApi.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private IClienteRepository? _clienteRepo;
        private IChamadoRepository? _chamadoRepo;
        private IRoleRepository? _roleRepo;
        private ISetorRepository? _setorRepo;
        public AppDbContext _context;
        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepo = _clienteRepo ?? new ClienteRepository(_context);
            }

        }
        public IChamadoRepository ChamadoRepository
        {
            get
            {
                return _chamadoRepo = _chamadoRepo ?? new ChamadoRepository(_context);
            }

        }

        public IRoleRepository  RoleRepository
        {
            get
            {
                return _roleRepo = _roleRepo ?? new RoleRepository(_context);
            }

        }

        public ISetorRepository SetorRepository
        {
            get
            {
                return _setorRepo = _setorRepo ?? new SetorRepository(_context);
            }

        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
