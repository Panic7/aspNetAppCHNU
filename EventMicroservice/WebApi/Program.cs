using Microsoft.EntityFrameworkCore;
using EventMicroservice.Repository;
using EventMicroservice.DAL;
using EventMicroservice.BLL.Services;
using EventMicroservice.BLL.SyncDataServices.Http;
using EventMicroservice.BLL.AsyncDataServices;
using EventMicroservice.BLL.SyncDataServices.Grpc;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

if (environment.IsProduction())
{
    Console.WriteLine("--> Using Production db");
    Console.WriteLine(builder.Configuration.GetConnectionString("EventContext"));
    builder.Services.AddDbContext<EventContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("EventContext")));
}
else
{
    Console.WriteLine("--> Using Dev db");
    builder.Services.AddDbContext<EventContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("EventContext")).EnableSensitiveDataLogging());
}


// Add services to the container.


builder.Services.AddTransient<EventRepository, EventRepository>();
builder.Services.AddTransient<EventService, EventService>();

builder.Services.AddTransient<CategoryRepository, CategoryRepository>();
builder.Services.AddTransient<CategoryService, CategoryService>();

builder.Services.AddTransient<IMessageBusClient, MessageBusClient>();
builder.Services.AddHttpClient<IGalleryDataClient, HttpGalleryDataClient>();

builder.Services.AddTransient<CityRepository, CityRepository>();
builder.Services.AddTransient<CityService, CityService>();

builder.Services.AddTransient<CountryRepository, CountryRepository>();
builder.Services.AddTransient<CountryService, CountryService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddGrpc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetRequiredService<EventContext>().Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGrpcService<GrpcEventService>();
app.MapGet("/protos/events.proto", async context =>
{
    await context.Response.WriteAsync(File.ReadAllText("../BLL/Protos/events.proto"));
});

app.Run();