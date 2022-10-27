using RepositoryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Author> Authors { get; }
        public IBookRepository Books    { get; }

        int complete();
    }
}
