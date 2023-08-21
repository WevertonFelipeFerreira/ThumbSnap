using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThumbSnap.Application.Commands.CreateVideoInformation;

namespace ThumbSnap.API.Controllers
{
    [ApiController]
    [Route("storyboard")]
    public class ThumbnailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ThumbnailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PostVideoPreview([FromBody] CreateVideoInformationCommand request)
        {
            // TODO remove this later when CQRS and repositories bee done
            // The code below is to test a image array as image/jpeg response, will be removed later
            //string videoUrl = "yourVideoUrl";
            //var image = GetImageAsByteArray(videoUrl);
            //var bytss = image[2];
            //return File(bytss, "image/jpeg");

            var result = await _mediator.Send(request);
            if (result is null)
            {
                return BadRequest(new { message = "Error on create video information" });
            }

            return Ok(result);
        }
    }
}
