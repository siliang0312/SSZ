using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Maintenance.Dtos;
using SSZ.Infrastructure.Data.Repositories;
using SSZ.UseCases.MaintenancePlans;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class CreateMaintenancePlanHandlerTests
{
  [Theory,AutoNSubstituteData]
  public async Task Handle_ShouldSaveSuccess(
    [Frozen]IMaintenanceRepository maintenanceRepository,
    CreateMaintenancePlanCommand command,
    IEnumerable<EquipAndItemDto> equipAndItem)
  {
    maintenanceRepository.GetEquipAndItemAsync().Returns(equipAndItem);
    var handler = new CreateMaintenancePlanHandler(maintenanceRepository);
    await handler.Handle(command, CancellationToken.None);
   await maintenanceRepository.Received().GetEquipAndItemAsync();
  }
}
