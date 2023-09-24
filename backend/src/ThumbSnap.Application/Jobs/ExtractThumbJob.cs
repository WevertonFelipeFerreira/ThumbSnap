using Quartz;
using ThumbSnap.Domain.Entities;
using ThumbSnap.Domain.Repositories;
using ThumbSnap.Domain.Services;

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
                //Job logic is here
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
