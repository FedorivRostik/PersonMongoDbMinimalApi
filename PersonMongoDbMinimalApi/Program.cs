using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Options;
using PersonMongoDbMinimalApi.Database;
using PersonMongoDbMinimalApi.Repository;
using PersonMongoDbMinimalApi.Services;
using PersonMongoDbMinimalApi.Validation;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.Configure<PersonDbSettings>(
               configuration.GetSection(nameof(PersonDbSettings)));

builder.Services.AddSingleton<IPersonDbSettings>(sp =>
               sp.GetRequiredService<IOptions<PersonDbSettings>>().Value);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddSingleton<IPersonDbSettings, PersonDbSettings>();
builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseOpenApi();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();
