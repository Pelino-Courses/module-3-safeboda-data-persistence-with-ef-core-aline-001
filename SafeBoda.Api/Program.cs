using SafeBoda.Application;
using SafeBoda.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();           // swager enablering

// registering repositories
builder.Services.AddScoped<ITripRepository, InMemoryTripRepository>();

var conn = builder.Configuration.GetConnectionString("SafeBodaDb");
builder.Services.AddDbContext<SafeBodaDbContext>(options =>
    options.UseSqlServer(conn));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();