using SSZ.Core.Aggregate.Equipment;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.ProductionLine;
using SSZ.Core.ContributorAggregate;

namespace SSZ.Infrastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options,
  IDomainEventDispatcher? dispatcher) : DbContext(options)
{
  private readonly IDomainEventDispatcher? _dispatcher = dispatcher;

  public DbSet<Contributor> Contributors => Set<Contributor>();
  public DbSet<ProductionLine> ProductionLines => Set<ProductionLine>();
  public DbSet<Equipment> Equipments => Set<Equipment>();
  public DbSet<MaintenanceItem> MaintenanceItems => Set<MaintenanceItem>();
  public DbSet<MaintenancePlan> MaintenancePlans => Set<MaintenancePlan>();
  public DbSet<MaintenanceTask> MaintenanceTasks => Set<MaintenanceTask>();
  public DbSet<MaintenanceRecord> MaintenanceRecords => Set<MaintenanceRecord>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<HasDomainEventsBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
        SaveChangesAsync().GetAwaiter().GetResult();
}
