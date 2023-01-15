using System.Runtime.ConstrainedExecution;
using ImageMicroservice.BLL.AsyncDataServices;
using ImageMicroservice.BLL.EventProcessing;
using ImageMicroservice.BLL.Services;
using ImageMicroservice.BLL.SyncDataServices.Grpc;
using ImageMicroservice.DAL;
using ImageMicroservice.DAL.Repositories;
using ImageMicroservice.WebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ImageContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("ImageContext")).EnableSensitiveDataLogging());
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddScoped<GalleryService, GalleryService>();

builder.Services.AddScoped<ImageRepository, ImageRepository>();
builder.Services.AddScoped<ImageService, ImageService>();

builder.Services.AddScoped<IImageCloudService, CloudinaryService>();

builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.AddScoped<IEventDataClient, EventDataClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ImageContext>().Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();
