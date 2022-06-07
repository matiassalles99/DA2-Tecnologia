using ServiceRegistrator;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var registrator = new Registrator(builder.Services);
registrator.RegisterBusinessLogicServices();
registrator.RegisterDataAccessServices();

// builder.Services.AddScoped<AuthorizationFilter>();

builder.Services.AddControllers(options => options.Filters.Add(new ExceptionFilter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                          .AllowAnyMethod()
                                                                          .AllowAnyHeader()));


var app = builder.Build();
app.UseCors("AllowAll");

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
