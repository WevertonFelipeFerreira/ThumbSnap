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
        public ExtractThumbJob(IVideoInformationRepository videoInformationRepository,
                               IVideoEngine engine,
                               IStorageService storage)
        {
            _videoInformationRepository = videoInformationRepository;
            _engine = engine;
            _storage = storage;
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

                        // CONTINUE
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
