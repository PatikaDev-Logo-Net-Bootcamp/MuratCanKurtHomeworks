using Homework5.API.Business;
using Homework5.API.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JsonPlaceHolderRecord
{
    public class PostsRecordWorker : BackgroundService
    {
        private readonly ILogger<PostsRecordWorker> _logger;
        private readonly IQueue<Post> _queue;
        private readonly IServiceScopeFactory _serviceFactory;

        public PostsRecordWorker(ILogger<PostsRecordWorker> logger, IServiceScopeFactory serviceFactory, IQueue<Post> queue)
        {
            _logger = logger;
            _serviceFactory = serviceFactory;
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{workername} Worker running at: {time}",nameof(PostsRecordWorker), DateTimeOffset.Now);
            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(1000, stoppingToken);
                    var post = _queue.Dequeue();
                    if (post == null) continue;

                    _logger.LogInformation("Processing next post.");
                    using (var scope = _serviceFactory.CreateScope())
                    {
                        var postService = scope.ServiceProvider.GetService<IPostService>();
                        await postService.AddPost(post,stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("An Error occured while processing posts. Exception: ",ex);
                }
            }
        }
    }
}
