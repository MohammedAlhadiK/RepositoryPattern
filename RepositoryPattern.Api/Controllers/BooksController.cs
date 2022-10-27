using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core.Consts;
using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(2));
        }
        [HttpGet("Find")]
        public IActionResult Find()
        {
            return Ok(_unitOfWork.Books.Find(x => x.ID == 2, new string[] { "Author" }));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.FindAll(x => x.AuthorID == 4, new string[] { "Author" }));
        }
        [HttpGet("GetAllPaged")]
        public IActionResult GetAllPaged()
        {
            return Ok(_unitOfWork.Books.FindAll(x => x.AuthorID == 1, 2, 1, new string[] { "Author" }));
        }

        [HttpGet("GetAllPagedOrdered")]
        public IActionResult GetAllPagedOrdered()
        {
            return Ok(_unitOfWork.Books.GetOrdered(x => x.AuthorID == 1, 1, 3, o => o.ID, OrderBy.Descending, includes: new string[] { "Author" }));
        }

    }
}
