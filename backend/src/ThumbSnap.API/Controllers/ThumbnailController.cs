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
            string videoUrl = "https://rr1---sn-bg07dnre.googlevideo.com/videoplayback?expire=1692144811&ei=S8DbZLewJOGwx_APn-Ca0Ao&ip=45.133.193.41&id=o-ACt7CagrZLoOrPqNCZ-zJvVpodSnvB2xFO1AfSh3D_qM&itag=18&source=youtube&requiressl=yes&spc=UWF9f_JZbynaK0kI0hDZDbhSUjTnBAA&vprv=1&svpuc=1&mime=video%2Fmp4&cnr=14&ratebypass=yes&dur=230.876&lmt=1664350850869653&fexp=24007246&c=ANDROID&txp=4538434&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cspc%2Cvprv%2Csvpuc%2Cmime%2Ccnr%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRQIgJQ8A7cxyDc7zBH50zWi2Zr5s4CBAt99t2MLU-SIuOZACIQC-4QbPSv44RUu1hH_ZcpXMifN06wmOFp8H2SSqoQR9Yw%3D%3D&title=Flo%20Rida%20-%20Low%20(feat.%20T-Pain)%20%5Bfrom%20Step%20Up%202%20The%20Streets%20O.S.T.%20%2F%20Mail%20On%20Sunday%5D%20(Official%20Video)&rm=sn-45gpjx-3x4e7e,sn-5hneze76&req_id=118380fc336da3ee&redirect_counter=2&cms_redirect=yes&cmsv=e&ipbypass=yes&mh=Bs&mip=2804:13a8:4eb:f453:a5e7:cb4c:8ad4:dd35&mm=29&mn=sn-bg07dnre&ms=rdu&mt=1692139517&mv=m&mvi=1&pl=49&lsparams=ipbypass,mh,mip,mm,mn,ms,mv,mvi,pl&lsig=AG3C_xAwRQIgORwtUX0HSrhJ7DBMFuK2Ft6KKr6tcXgpFEoqvhi0DCwCIQCoGFX6Ad0MbwFx3uVciycOq4rK6tDKuXNqvoAhAvzdoQ%3D%3D";

            var image = GetImageAsByteArray(videoUrl);
            var bytss = image[54];
            return File(bytss, "image/jpeg");
        }

        private List<byte[]> GetImageAsByteArray(string videoUrl)
        {
            List<byte[]> listOfByteArray = new();
            using (VideoCapture capture = new VideoCapture(videoUrl))
            {
                if (!capture.IsOpened)
                {
                    Console.WriteLine("Não foi possível abrir o vídeo.");
                }

                var interval = TimeSpan.FromSeconds(2);
                var startTime = TimeSpan.Zero;
                var outputImageCount = 0;

                while (true)
                {
                    using (Mat frame = new Mat())
                    {
                        capture.Read(frame);

                        if (frame.IsEmpty)
                            break;

                        var timestamp = TimeSpan.FromSeconds(capture.Get(CapProp.PosFrames) / capture.Get(CapProp.Fps));

                        if (timestamp >= startTime)
                        {
                            using (VectorOfByte memoryStream = new VectorOfByte())
                            {
                                CvInvoke.Imencode(".jpg", frame, memoryStream);

                                listOfByteArray.Add(memoryStream.ToArray());

                                startTime += interval;
                                outputImageCount++;
                            }
                        }
                    }
                }
            }

            return listOfByteArray;
        }
    }
}
