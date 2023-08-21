using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using ThumbSnap.Domain.Enums;
using ThumbSnap.Domain.Services;

namespace ThumbSnap.Application.Services
{
    public class VideoEngine : IVideoEngine
    {
        public VideoCapture? GetVideoCapture(string path)
        {
            var videoCapture = new VideoCapture(path);

            return videoCapture.IsOpened ? videoCapture : null;
        }

        public IEnumerable<byte[]> GetVideoFramesByteArray(VideoCapture videoCapture, int snapEverySecond = 10, int snapWidth = 320, int snapHeight = 180, ImagesFormats imageFormat = ImagesFormats.Jpg)
        {
            List<byte[]> imagesInByteArray = new();

            var interval = TimeSpan.FromSeconds(snapEverySecond);
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
                    CvInvoke.Imencode(GetImageFormat(imageFormat), frame, memoryStream);
                    imagesInByteArray.Add(memoryStream.ToArray());

                    startTime += interval;
                }
            }

            return imagesInByteArray;
        }

        private string GetImageFormat(ImagesFormats imageFormat)
        {
            return imageFormat switch
            {
                ImagesFormats.Png => ".png",
                _ => ".jpg"
            };
        }
    }
}
