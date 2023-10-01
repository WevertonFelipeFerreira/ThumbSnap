using Emgu.CV;
using ThumbSnap.Domain.Enums;
using ThumbSnap.Domain.DTOs;

namespace ThumbSnap.Domain.Services
{
    public interface IVideoEngine
    {
        VideoCapture? GetVideoCapture(string path);
        IEnumerable<ImageDto> GetVideoFramesByteArray(VideoCapture videoCapture, int snapEverySecond = 10, int? snapWidth = 320, int? snapHeight = 180, ImagesFormats imageFormat = ImagesFormats.Jpg);
    }
}