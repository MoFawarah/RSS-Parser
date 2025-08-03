
using RssJobParserApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddMemoryCache();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IGeocodingService, GeocodingService>();
builder.Services.AddHttpClient<IRssService, RssService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();              
    app.UseSwaggerUI();           
}

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
