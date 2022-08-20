using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QulixTask.Entities;
using QulixTask.Payload.ResponseDto;
using QulixTask.Payload.RequestDto;
using QulixTask.Exceptions;
using QulixTask.Services;

namespace QulixTask.Controllers
{
    [Route("api/text")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly ITextService textService;

        public TextController(ITextService textService)
        {
            this.textService = textService;
        }

        [HttpGet]
        public ActionResult GetAllTexts(int pageNumber, int pageSize)
        {
            return new OkObjectResult(textService.GetTexts(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public ActionResult GetText(Guid id)
        {
            TextDto textDto = textService.GetText(id);
            if (textDto is null)
                return NotFound();
            return new OkObjectResult(textDto);
        }

        [HttpPost]
        public ActionResult CreateText(CreateTextDto textDto)
        {
            try
            {
                Text text = textService.CreateText(textDto);
                return CreatedAtAction(
                    nameof(CreateText),
                    new { id = text.Id },
                    textService.ConvertToDto(text)
                    );
            }
            catch (AuthorNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
