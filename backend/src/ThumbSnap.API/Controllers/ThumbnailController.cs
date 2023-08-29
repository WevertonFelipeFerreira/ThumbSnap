using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThumbSnap.Application.Commands.CreateVideoInformation;
using ThumbSnap.Application.Queries.GetAllPaginatedVideoInformation;
using ThumbSnap.Application.ViewModels;
using ThumbSnap.Domain.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;

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
        [ProducesResponseType(typeof(VideoInformationVM), Status201Created)]
        public async Task<IActionResult> PostVideoPreview([FromBody] CreateVideoInformationCommand request)
        {
            var result = await _mediator.Send(request);

            return Created("storyboard", result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginationResult<VideoInformationVM>), Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllVideoInformationsQuery request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
