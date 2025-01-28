using KamathResidency.Infrastructure;
using KamathResidency.Repos.Implementations;
using KamathResidency.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
var config = builder.Configuration;

// Add configuration

config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    ;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        ///var allowedOrigins = config.GetSection("AllowedOrigins").Get<string[]>();
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        ;
    });
});
builder.Services.AddControllers();

builder.Services.AddDbContext<HotelDbContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

