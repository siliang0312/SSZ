using AutoFixture;
using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class PastMaintenancePlanCustomization:ICustomization
{
  public void Customize(IFixture fixture)
  {
    fixture.Customize<MaintenancePlan>(composer =>
      composer.With(p => p.NextDateTime, () => DateTime.UtcNow.AddMinutes(-Random.Shared.Next(1, 1000))));
  }
}
