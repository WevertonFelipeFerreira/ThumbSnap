using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using ThumbSnap.Application.Jobs;

namespace ThumbSnap.IoC.Configurations
{
    public static class QuartzJobs
    {
        public static IServiceCollection AddJobs(this IServiceCollection services, IConfiguration config)
        {
            services.AddQuartz(q =>
            {
                q.AddJobAndTrigger<ExtractThumbJob>(config);
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            return services;
        }

        private static void AddJobAndTrigger<T>(this IServiceCollectionQuartzConfigurator quartz, IConfiguration config)
            where T : IJob
        {
            string jobName = typeof(T).Name;

            var configKey = $"CronJobs:{jobName}";
            var cronSchedule = config[configKey];

            if (!string.IsNullOrEmpty(cronSchedule))
            {
                string jobGroup = $"{jobName}Group";
                string triggerName = $"{jobName}-trigger";

                var jobKey = new JobKey(jobName, jobGroup);
                var triggerKey = new TriggerKey(triggerName, jobGroup);

                quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));
                quartz.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity(triggerKey)
                    .WithCronSchedule(cronSchedule));
            }
            else
            {
                // TODO: Remova Console.WriteLine quando um logger for implementado
                Console.WriteLine($"Could not find Cron schedule found for job in configuration at {configKey}");
            }
        }
    }
}
