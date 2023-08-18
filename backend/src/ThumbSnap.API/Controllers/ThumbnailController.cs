using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Microsoft.AspNetCore.Mvc;

namespace ThumbSnap.API.Controllers
{
    [ApiController]
    [Route("thumbnail")]
    public class ThumbnailController : ControllerBase
    {
        [HttpPost("video-preview")]
        public async Task<IActionResult> PostVideoPreview()
        {
            string videoUrl = "yourVideoUrl";

            var image = GetImageAsByteArray(videoUrl);
            var bytss = image[2];
            return File(bytss, "image/jpeg");
        }

        private List<byte[]> GetImageAsByteArray(string videoUrl, int PhotoEverySeconds = 10)
        {
            List<byte[]> imagesInByteArray = new();
            var videoCapture = new VideoCapture(videoUrl);

            if (!videoCapture.IsOpened)
            {
                throw new Exception("Could not open the video!");
            }

            var interval = TimeSpan.FromSeconds(PhotoEverySeconds);
            var startTime = TimeSpan.Zero;

            while (true)
            {
                var frame = new Mat();
                videoCapture.Read(frame);

                if (frame.IsEmpty)
                    break;

                var timestamp = TimeSpan.FromSeconds(videoCapture.Get(CapProp.PosFrames) / videoCapture.Get(CapProp.Fps));
                if (timestamp >= startTime)
                {
                    var memoryStream = new VectorOfByte();
                    CvInvoke.Imencode(".jpg", frame, memoryStream);
                    imagesInByteArray.Add(memoryStream.ToArray());

                    startTime += interval;
                }
            }

            return imagesInByteArray;
        }
    }
}
