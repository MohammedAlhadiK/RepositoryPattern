using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.EF.Classes
{
    public class Bookrepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public Bookrepository(ApplicationDBContext dBContext) : base(dBContext)
        {
        }
        public Book GetBook(int id)
        {
            return new Book();
        }
    }
}
