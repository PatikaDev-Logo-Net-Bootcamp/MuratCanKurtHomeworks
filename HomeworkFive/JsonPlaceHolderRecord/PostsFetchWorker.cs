using Homework5.API.Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JsonPlaceHolderRecord
{
    public class PostsFetchWorker : BackgroundService
    {
        private readonly ILogger<PostsFetchWorker> _logger;
        private readonly IQueue<Post> _queue;
        private HttpClient _httpClient;

        public PostsFetchWorker(ILogger<PostsFetchWorker> logger, IQueue<Post> queue)
        {
            _logger = logger;
            _queue = queue;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _httpClient = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                var request = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
                if (request.IsSuccessStatusCode)
                {
                    var content = await request.Content.ReadAsStringAsync();
                    List<Post> posts = JsonSerializer.Deserialize<List<Post>>(content,new JsonSerializerOptions { PropertyNameCaseInsensitive=true});
                    foreach (var post in posts)
                    {
                        _queue.Enqueue(post);
                        _logger.LogInformation("Processing post, id:{}, title:'{}' added to queue.", post.Id, post.Title);
                    }
                }
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            base.Dispose();
            return base.StopAsync(cancellationToken);
        }
    }
}
