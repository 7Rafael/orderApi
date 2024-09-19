using orderApi.Context;
using orderApi.Repository.ChamadoRepositories;
using orderApi.Repository.SetorRepositories;

namespace orderApi.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private IChamadoRepository? _chamadoRepo;
        private ISetorRepository? _setorRepo;
        public AppDbContext _context;
        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IChamadoRepository ChamadoRepository
        {
            get
            {
                return _chamadoRepo = _chamadoRepo ?? new ChamadoRepository(_context);
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
