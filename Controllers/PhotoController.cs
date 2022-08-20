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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QulixTask.Controllers
{
    [Route("api/photo")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService photoService;

        public PhotoController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        [HttpGet]
        public ActionResult GetPhotos(int pageNumber, int pageSize)
        {
            return new OkObjectResult(photoService.GetPhotos(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public ActionResult<PhotoDto> GetPhoto(Guid id)
        {
            PhotoDto photoDto = photoService.GetPhoto(id);
            if (photoDto is null)
                return NotFound();
            return new OkObjectResult(photoDto);
        }



        [HttpPut("{id}")]
        public ActionResult UpdatePhoto(Guid id, UpdatePhotoDto photoDto) 
        {
            try
            {
                photoService.UpdatePhoto(id, photoDto);             
                return NoContent();
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("rate/{id}")]
        public ActionResult RatePhoto(RateItemDto rateItemDto)
        {
            try
            {
                photoService.RatePhoto(rateItemDto);
                return NoContent();
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult CreatePhoto(CreatePhotoDto photoDto)
        {
            try
            {
                Photo photo = photoService.CreatePhoto(photoDto);
                return CreatedAtAction(
                    nameof(CreatePhoto),
                    new { id = photo.Id },
                    photoService.ConvertToDto(photo)
                    );
            }
            catch (AuthorNotFoundException)
            {
                return BadRequest();
            }
        }

    }
}
