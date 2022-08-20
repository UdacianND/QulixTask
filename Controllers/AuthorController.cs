using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Services;

namespace QulixTask.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }
        [HttpGet]
        public ActionResult GetAuthors()
        {
            return new OkObjectResult(authorService.GetAuthors());
        }

        [HttpPost]
        public ActionResult AddAuthor(CreateAuthorDto authorDto)
        {
            try
            {
                Author author = authorService.AddNewAuthor(authorDto);
                return CreatedAtAction(
                    nameof(AddAuthor),
                    new { id = author.Id },
                    author.ToAuthorDto()
                    );
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
