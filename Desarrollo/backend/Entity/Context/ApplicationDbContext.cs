using Dapper;
using Entity.Model;
using Entity.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext() { } // Necesario para las migraciones

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<RoomPlayers> Pedidos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación Cliente 1 ---- * Pedido
        modelBuilder.Entity<RoomPlayers>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación Pizza 1 ---- * Pedido
        modelBuilder.Entity<RoomPlayers>()
            .HasOne(p => p.Pizza)
            .WithMany(pi => pi.Pedidos)
            .HasForeignKey(p => p.PizzaId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=PizzeriaOpitaDb;Trusted_Connection=True;");
        }
    }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
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

    // Métodos Dapper
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


    /// <summary>
    /// Estructura para ejecutar comandos SQL con Dapper en Entity Framework Core.
    /// </summary>
    public readonly struct DapperEFCoreCommand : IDisposable
    {
        /// <summary>
        /// Constructor del comando Dapper.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        /// <param name="text">Consulta SQL.</param>
        /// <param name="parameters">Parámetros opcionales.</param>
        /// <param name="timeout">Tiempo de espera opcional.</param>
        /// <param name="type">Tipo de comando SQL opcional.</param>
        /// <param name="ct">Token de cancelación.</param>
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

        /// <summary>
        /// Define los parámetros del comando SQL.
        /// </summary>
        public CommandDefinition Definition { get; }

        /// <summary>
        /// Método para liberar los recursos.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
