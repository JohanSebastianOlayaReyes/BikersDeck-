// using AutoMapper;
// using Back_end.Context;
// using Business;
// using Business.Implements;
// using Business.Interfaces;
// using Data;
// using Data.Implements.BaseData;
// using Data.Interface;
// using Entity.Dtos.PedidoDto;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Migrations;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();





// // AutoMapper: registra todos los perfiles del ensamblado donde están definidos
// builder.Services.AddAutoMapper(typeof(PlayersProfile).Assembly);

// // Player
// builder.Services.AddScoped<IPlayerData, PlayerData>();
// builder.Services.AddScoped<IPlayerBusiness, PlayerBusiness>();

// // RoomPlayers
// builder.Services.AddScoped<IRoomPlayersData, RoomPlayerData>();
// builder.Services.AddScoped<IRoomPlayersBusiness, RoomPlayersBusiness>();

// // Game
// builder.Services.AddScoped<IGameData, GameData>();
// builder.Services.AddScoped<IGameBusiness, GameBusiness>();

// // Mazo
// builder.Services.AddScoped<IMazoData, MazoData>();
// builder.Services.AddScoped<IMazoBusiness, MazoBusiness>();

// // Card
// builder.Services.AddScoped<ICardData, CardData>();
// builder.Services.AddScoped<ICardBusiness, CardBusiness>();

// // Round
// builder.Services.AddScoped<IRoundData, RoundData>();
// builder.Services.AddScoped<IRoundBusiness, RoundBusiness>();

// // Turn
// builder.Services.AddScoped<ITurnData, TurnData>();
// builder.Services.AddScoped<ITurnBusiness, TurnBusiness>();




// // Agregar CORS
// var OrigenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
// builder.Services.AddCors(opciones =>
// {
//     opciones.AddDefaultPolicy(politica =>
//     {
//         politica.WithOrigins(OrigenesPermitidos).AllowAnyHeader().AllowAnyMethod();
//     });
// });

// // Configuración de base de datos dinámica
// var databaseProvider = builder.Configuration.GetValue<string>("DatabaseProvider") ?? "MySql";

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
// {
//     switch (databaseProvider.ToLower())
//     {
//         case "mysql":
//             var mysqlConnection = builder.Configuration.GetConnectionString("MySqlConnection") 
//                 ?? builder.Configuration.GetConnectionString("DefaultConnection");
//             options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection));
//             break;
        
//         case "sqlserver":
//             var sqlServerConnection = builder.Configuration.GetConnectionString("SqlServerConnection");
//             options.UseSqlServer(sqlServerConnection);
//             break;
        
//         default:
//             // Por defecto usar MySQL con Pomelo
//             var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//             options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection));
//             break;
//     }
// });

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// // app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();