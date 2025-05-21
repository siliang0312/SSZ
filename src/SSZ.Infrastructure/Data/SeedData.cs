using SSZ.Core.Aggregate.Equipment;
using SSZ.Core.ContributorAggregate;

namespace SSZ.Infrastructure.Data;

public static class SeedData
{
  public static readonly Contributor Contributor1 = new("Ardalis");
  public static readonly Contributor Contributor2 = new("Snowfrog");
  public static readonly Equipment Equipment1 = new("压铸机台1","2032u13");
  public static readonly Equipment Equipment2 = new("压铸机台2","1323123");

  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    if (await dbContext.Contributors.AnyAsync()) return; // DB has been seeded
    // if (await dbContext.Equipments.AnyAsync()) return; // DB has been seeded

    await PopulateTestDataAsync(dbContext);
  }

  public static async Task PopulateTestDataAsync(AppDbContext dbContext)
  {
    dbContext.Contributors.AddRange([Contributor1, Contributor2]);
    // dbContext.Equipments.AddRange([Equipment1, Equipment2]);
    await dbContext.SaveChangesAsync();
  }
}
