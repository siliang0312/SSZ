using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Dtos;
using SSZ.Infrastructure.Data.Repositories;
using SSZ.UseCases.MaintenancePlans;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class CreateMaintenancePlanHandlerTests
{
  [Theory,AutoNSubstituteData]
  public async Task Handle_ShouldSaveSuccess(
    [Frozen]IMaintenanceRepository maintenanceRepository,
    [Frozen]IRepository<MaintenanceItem> itemRepository,
    CreateMaintenancePlanCommand command,
    IEnumerable<EquipAndItemDto> equipAndItem,
    IEnumerable<MaintenanceItem> maintenanceItems
    )
  {
    maintenanceRepository.GetEquipAndItemAsync().Returns(equipAndItem);
    itemRepository.ListAsync().Returns(maintenanceItems.ToList());
    var handler = new CreateMaintenancePlanHandler(maintenanceRepository,itemRepository);
    await handler.Handle(command, CancellationToken.None);
   await maintenanceRepository.Received().GetEquipAndItemAsync();
   await itemRepository.Received().ListAsync();
  }
}
