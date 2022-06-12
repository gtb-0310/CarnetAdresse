using CarnetAdresseApi.Models;
using CarnetAdresseApi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CarnetAdresseDatabaseSettings>(
    builder.Configuration.GetSection("CarnetAdresse"));
builder.Services.AddSingleton<PeopleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); On commente cette ligne car on utilise des requêtes HTTP, et non HTTPS

app.UseAuthorization();

app.MapControllers();

app.Run();
