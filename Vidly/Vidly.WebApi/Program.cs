using Vidly.Factory;
using Vidly.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var factory = new ServiceFactory();
factory.RegisterServices(builder.Services);

// En add controllers, puedo registrar filtros de forma global
builder.Services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));

// Si quiero usar inyeccion de dependencia en los filtros, tengo que registrarlos como service filters
builder.Services.AddScoped<AuthenticationFilter>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
