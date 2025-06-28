using CrudVeiculos.Data;
using CrudVeiculos.Extensions;
using Microsoft.EntityFrameworkCore;
using Minio;

var builder = WebApplication.CreateBuilder(args);
var minioConfig = builder.Configuration.GetSection("Minio");
string endpoint = minioConfig["Endpoint"];
bool useSSL = bool.Parse(minioConfig["UseSSL"]);
string accessKey = minioConfig["AccessKey"];
string secretKey = minioConfig["SecretKey"];

// 1) CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalReact", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// 2) Minio
builder.Services.Configure<MinioSettings>(
    builder.Configuration.GetSection("Minio"));

builder.Services.AddSingleton<MinioClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MinioSettings>>().Value;
    return new MinioClient()
                  .WithEndpoint(settings.Endpoint)
                  .WithCredentials(settings.AccessKey, settings.SecretKey)
                  .WithSSL(settings.UseSSL)
                  .Build();
});
builder.Services
    .AddScoped<IFileStorageService, MinioFileStorageService>();


// 3) Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddApplicationServices();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 3) Swagger em Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4) CORS antes de MapControllers
app.UseCors("AllowLocalReact");

app.UseHttpsRedirection();
app.MapControllers();

// 5) Aplica migrações automáticas
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();
