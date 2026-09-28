using FD.TechTest.LibraryManagement.Domain.Repositories;
using FD.TechTest.LibraryManagement.Domain.Services;
using FD.TechTest.LibraryManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();


void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IBookRepository, BookRepository>();
    services.AddScoped<ILibraryService, LibraryService>();
    services.AddScoped<ICustomerRepository, CustomerRepository>();
}