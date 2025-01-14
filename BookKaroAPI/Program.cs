using BookKaroAPI.Middleware;
using PersistenceService.Configurations;
using Bussiness.Configurations;
using InfrastructureServices.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.InjectPersistenceServices(builder.Configuration);
builder.Services.InjectInfrastructureServiceCollection();
builder.Services.InjectBusinessServices();

builder.Services.AddExceptionHandler<ExceptionHandlerMiddleware>();

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(o => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
