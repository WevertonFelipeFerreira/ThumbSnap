using Microsoft.AspNetCore.Mvc;

namespace ThumbSnap.API.Controllers
{
    [ApiController]
    [Route("storyboard")]
    public class ThumbnailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostVideoPreview()
        {
            // TODO remove this later when CQRS and repositories bee done
            // The code below is to test a image array as image/jpeg response, will be removed later
            //string videoUrl = "yourVideoUrl";
            //var image = GetImageAsByteArray(videoUrl);
            //var bytss = image[2];
            //return File(bytss, "image/jpeg");

            return Ok();
        }
    }
}
