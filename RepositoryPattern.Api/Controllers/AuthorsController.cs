using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _UnitOfWork;
        //private readonly IGenericRepository<Author> _UnitOfWork;
        public AuthorsController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            return Ok(_UnitOfWork.Authors.GetById(1));
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _UnitOfWork.Authors.GetByIdAsync(1));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_UnitOfWork.Authors.GetAll().ToList());
        }
        [HttpGet("Find")]
        public IActionResult Find()
        {
            return Ok(_UnitOfWork.Authors.Find(x => x.Name == "tt"));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne(Author author)
        {
            var CurrentAuthor = _UnitOfWork.Authors.Add(author);
            _UnitOfWork.complete();
            return Ok(CurrentAuthor);
        }
        [HttpPut("UpdateOne")]
        public IActionResult UpdateOne(Author author)
        {
            _UnitOfWork.Authors.Update(author);
            _UnitOfWork.complete();
            return Ok();
        }
        [HttpDelete("DeleteOne")]
        public IActionResult DeleteOne(Author author)
        {
            _UnitOfWork.Authors.Delete(author);
            _UnitOfWork.complete();

            return Ok();
        }

        [HttpPost("AddRange")]
        public IActionResult AddRange(IQueryable<Author> authors)
        {
            _UnitOfWork.Authors.AddRange(authors);
            _UnitOfWork.complete();

            return Ok();
        }
        [HttpPost("UpdateRange")]
        public IActionResult UpdateRange([FromBody] List<Author> authors)
        {
            _UnitOfWork.Authors.UpdateRange(authors);
            _UnitOfWork.complete();

            return Ok();
        }
        [HttpDelete("DeleteRange")]
        public IActionResult DeleteRange(List<Author> authors)
        {
            _UnitOfWork.Authors.DeleteRange(authors);
            _UnitOfWork.complete();

            return Ok();
        }
    }
}
