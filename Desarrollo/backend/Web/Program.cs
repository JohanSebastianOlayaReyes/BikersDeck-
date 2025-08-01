using Business.Implements;
using Business.Interfaces;
using Data.Implements;
using Data.Implements.BaseData;
using Data.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Utilities.Mappers.Profiles;
using Web.ServiceExtension;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));


// Swagger
builder.Services.AddSwaggerDocumentation();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register generic repositories and business logic
builder.Services.AddScoped(typeof(IBaseModelData<>), typeof(BaseModelData<>));
builder.Services.AddScoped(typeof(IBaseBusiness<,>), typeof(BaseBusiness<,>));

builder.Services.AddScoped<IClienteData, ClienteData>();
builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();

builder.Services.AddScoped<IPizzaData, PizzaData>();
builder.Services.AddScoped<IPizzaBusiness, PizzaBusiness>();

builder.Services.AddScoped<IPedidoData, PedidoData>();
builder.Services.AddScoped<IPedidoBusiness, PedidoBusiness>();

builder.Services.AddAutoMapper(typeof(PlayersProfile));
builder.Services.AddAutoMapper(typeof(PizzaProfile));
builder.Services.AddAutoMapper(typeof(PedidoProfile));




var app = builder.Build();

// Swagger (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Sistema de Gestión v1");
        c.RoutePrefix = string.Empty;
    });
}

// Usa la política de CORS registrada en ApplicationServiceExtensions
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

// Autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Inicializar base de datos y aplicar migraciones
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();

        dbContext.Database.Migrate();
        logger.LogInformation("Base de datos verificada y migraciones aplicadas exitosamente.");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error durante la migración de la base de datos.");
    }
}

app.Run();
