using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoApi10062024.Service;
using MongoApi10062024.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ProjMongoDBApiConfig>(builder.Configuration.GetSection(nameof(ProjMongoDBApiConfig)));

builder.Services.AddSingleton<IProjMongoDBApiConfig>(sp => sp.GetRequiredService<IOptions<ProjMongoDBApiConfig>>().Value);

builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<AddressService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
