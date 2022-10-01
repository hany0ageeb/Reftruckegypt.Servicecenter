using Reftruckegypt.Servicecenter.Data.Abstractions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed = false;
        private ReftruckDbContext _context;
        public UnitOfWork(ReftruckDbContext context)
        {
            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _context.Dispose();
                _isDisposed = true;
            }
        }
    }
}
