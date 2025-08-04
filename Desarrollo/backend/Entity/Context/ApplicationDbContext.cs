using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using Entity.Model;

namespace Back_end.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext() { }

        ///
        /// DB SETS
        ///
        public DbSet<Game> Games { get; set; }
        public DbSet<Mazo> Mazos { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<RoomPlayers> RoomPlayers { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Turn> Turns { get; set; }


        /// <summary>
        /// Configura los modelos de la base de datos aplicando configuraciones desde ensamblados.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de base de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación: Player (1) ---> (n) RoomPlayers
            modelBuilder.Entity<RoomPlayers>()
                .HasOne(rp => rp.Players)
                .WithMany(p => p.RoomPlayers)
                .HasForeignKey(rp => rp.PlayersId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: RoomPlayer (1) ---> (n) Games
            modelBuilder.Entity<Game>()
                .HasOne(g => g.RoomPlayers)
                .WithMany(rp => rp.Game)
                .HasForeignKey(g => g.RoomPlayersId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Game (1) ---> (n) Mazo
            modelBuilder.Entity<Mazo>()
                .HasOne(m => m.Game)
                .WithMany(g => g.Mazos)
                .HasForeignKey(m => m.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Mazo (1) ---> (n) Card
            modelBuilder.Entity<Mazo>()
                .HasOne(c => c.card)
                .WithMany(m => m.Mazos)
                .HasForeignKey(c => c.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Game (1) ---> (n) Rounds
            modelBuilder.Entity<Round>()
                .HasOne(r => r.Game)
                .WithMany(g => g.Rounds)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Round (1) ---> (n) Turns
            modelBuilder.Entity<Turn>()
                .HasOne(t => t.Round)
                .WithMany(r => r.Turns)
                .HasForeignKey(t => t.RoundId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            public CommandDefinition Definition { get; }

            public void Dispose() { }
        }
    }
}