using System.Text;
using System.Text.Json;
using EventMicroservice.BLL.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EventMicroservice.BLL.SyncDataServices.Http
{
    public class HttpGalleryDataClient : IGalleryDataClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly ILogger<HttpGalleryDataClient> logger;
        public HttpGalleryDataClient(HttpClient httpClient, IConfiguration configuration, ILogger<HttpGalleryDataClient> logger)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.logger = logger;
        }
        public async Task SendEventToGallery(EventResponse ev)
        {
            logger.LogInformation($"-->It's HttpGalleryDataClient, SendEventToGallery method. Event.id = {ev.Id}");
            var httpContent = new StringContent(
                JsonSerializer.Serialize(ev),
                Encoding.UTF8,
                "application/json"
            );
            logger.LogInformation($"-->We'll trying now do post async to {configuration["ImageMicroservice"]}");
            var response = await httpClient.PostAsync($"{configuration["ImageMicroservice"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("--> Sync POST to ImageMicroservice was OK!");
            }
            else
            {
                logger.LogInformation("--> Sync POST to ImageMicroservice was NOT OK!");
            }
        }
    }
}