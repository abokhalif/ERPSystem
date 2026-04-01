using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOWCore.Models;
using RepositoryPatternWithUOWCore.Repositories;

namespace RepositoryPatternWithUOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(unitOfWork.Authors.GetById(id));

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Authors")]
        public IActionResult GetAllAuthors()
        {
            return Ok(unitOfWork.Authors.GetAll());
        }
        //Find function with predicate
        [HttpGet("FindAuthorByName")]
        public IActionResult FindAuthorByName(string name)
        {
            return Ok(unitOfWork.Authors.Find(a=>a.Name==name));
        }

    }
}
