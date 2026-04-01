using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOWCore.Consts;
using RepositoryPatternWithUOWCore.Models;
using RepositoryPatternWithUOWCore.Repositories;
using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [Authorize]//check if the cookies is expired or not(mean if the user logout or not on this action only)
        [HttpGet]
        public IActionResult GetBookById(int id)
        {
            return Ok(unitOfWork.Books.GetById(id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllBooks()
        {
            return Ok(unitOfWork.Books.GetAll());
        }
        [HttpGet("FindBookByTitle")]
        public IActionResult FindBookByTitle(string title)
        {
            return Ok(unitOfWork.Books.Find(a => a.Title == title));
        }
        [HttpGet("FindBookwithAuthor")]
        public IActionResult FindBooks(string title)
        {
            return Ok(unitOfWork.Books.Find(a => a.Title == title, new[]{"Author"}));
        }
        [HttpGet("FindAllBooks")]
        public IActionResult FindAllBooks(string Contain)
        {
            return Ok(unitOfWork.Books.FindAll(a => a.Title.Contains(Contain), new[] { "Author" }));
        }
        [HttpGet("FindAll")]

        public IActionResult FindAll(string Contain)
        {
            return Ok(unitOfWork.Books.FindAll(a => a.Title.Contains(Contain),null,null,a=>a.Id,OrderBy.Descending));
        }
        [HttpPost("AddOne")]

        public IActionResult AddOne(Book book)
        {
            var newbook = unitOfWork.Books.Add(book);
            unitOfWork.Complete();
            return Ok(newbook);
        }


    }
}
