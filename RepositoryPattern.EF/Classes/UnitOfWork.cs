using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.Core.Models;

namespace RepositoryPattern.EF.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _DBContext;
        public UnitOfWork(ApplicationDBContext DBContext)
        {
            _DBContext = DBContext;
            Authors = new GenericRepository<Author>(_DBContext);
            Books = new Bookrepository(_DBContext);
        }
        public IGenericRepository<Author> Authors { get; private set; }
        public IBookRepository Books { get; private set; }

        public int complete()
        {
            return _DBContext.SaveChanges();
        }

        public void Dispose()
        {
            _DBContext.Dispose();
        }
    }
}
