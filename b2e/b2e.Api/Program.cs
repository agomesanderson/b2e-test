using b2e.Api.Configurations;
using b2e.Infra.Database;
using b2e.Infra.Database.Extensions;
using b2e.Infra.Database.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServerDbContext<b2eContext>(builder.Configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDocs();
builder.Services.AddVersioning();
builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .AllowAnyOrigin() // ou .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

app.AddMigration<b2eContext>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.UseDocs();

app.MapControllers();

app.Run();
