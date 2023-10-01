using AutoMapper;
using Quartz;
using ThumbSnap.Domain.Entities;
using ThumbSnap.Domain.Exceptions;
using ThumbSnap.Domain.Repositories;
using ThumbSnap.Domain.Services;
using static ThumbSnap.Domain.Enums.StoryboardProcessingStatus;

namespace ThumbSnap.Application.Jobs
{
    [DisallowConcurrentExecution]
    public class ExtractThumbJob : IJob
    {
        private readonly IVideoInformationRepository _videoInformationRepository;
        private readonly IVideoEngine _engine;
        private readonly IStorageService _storage;
        private readonly IMapper _mapper;
        public ExtractThumbJob(IVideoInformationRepository videoInformationRepository,
                               IVideoEngine engine,
                               IStorageService storage,
                               IMapper mapper)
        {
            _videoInformationRepository = videoInformationRepository;
            _engine = engine;
            _storage = storage;
            _mapper = mapper;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            //TODO Remove Console.WriteLine when logger will be implemented
            Console.WriteLine($"EXTRACT THUMB JOB INICIADO");
            try
            {
                var videoInformations = await _videoInformationRepository.GetAsync(x => x.StoryboardProcessingStatus == InQueue);

                if (!videoInformations.Any())
                    return;

                foreach (var videoInformation in videoInformations)
                {
                    try
                    {

                        videoInformation.StoryboardProcessingStatus = Processing;
                        await _videoInformationRepository.UpdateAsync(videoInformation);

                        var videoCapture = _engine.GetVideoCapture(videoInformation.Path);
                        if (videoCapture is null)
                            throw new InvalidVideoPathException();

                        videoInformation.Width = videoCapture.Width;
                        videoInformation.Height = videoCapture.Height;

                        var imageAsBytes = _engine.GetVideoFramesByteArray(videoCapture,
                                                                           videoInformation.SnapTakenEverySeconds,
                                                                           videoInformation.Width,
                                                                           videoInformation.Height).OrderBy(x => x.Time);
                        int count = 1;
                        List<StoryboardSnap> snaps = new();
                        foreach (var image in imageAsBytes)
                        {
                            var snap = _mapper.Map<StoryboardSnap>(image);
                            Stream bytesAsStream = new MemoryStream(image.Bytes);
                            var name = videoInformation.Name + $"-{count}";
                            var path = await _storage.UploadFile(bytesAsStream, videoInformation.Id.ToString(), name, snap.Extension);
                            snap.Path = path;
                            snaps.Add(snap);
                            count++;
                        }

                        videoInformation.StoryboardProcessingStatus = Done;
                        videoInformation.Snaps = snaps;

                        await _videoInformationRepository.UpdateAsync(videoInformation);
                    }
                    catch (InvalidVideoPathException ex)
                    {
                        videoInformation.StoryboardProcessingStatus = Rejected;
                        videoInformation.RejectionMessage = $"{ex.Message} ------> {ex.StackTrace}";
                        await _videoInformationRepository.UpdateAsync(videoInformation);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AN ERROR OCCURRED ON JOB EXECUTION: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("FINISHED EXTRACT THUMB JOB");
            }
        }
    }
}
