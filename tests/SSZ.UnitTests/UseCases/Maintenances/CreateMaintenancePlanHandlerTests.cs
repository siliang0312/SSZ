using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Interfaces;
using SSZ.UseCases;
using SSZ.UseCases.MaintenancePlans;
using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class CreateMaintenancePlanHandlerTests
{
  [Theory,AutoNSubstituteData]
  public async Task Handle_ShouldSaveSuccess(
    [Frozen]IMaintenanceRepository maintenanceRepository,
    [Frozen]IRepository<MaintenanceItem> itemRepository,
    [Frozen]IMaintenanceQueryService queryService,
    CreateMaintenancePlanCommand command,
    IEnumerable<EquipAndItemDto> equipAndItem,
    IEnumerable<MaintenanceItem> maintenanceItems
    )
  {
    queryService.GetEquipAndItemAsync().Returns(equipAndItem);
    itemRepository.ListAsync().Returns(maintenanceItems.ToList());
    var handler = new CreateMaintenancePlanHandler(maintenanceRepository,itemRepository,queryService);
    await handler.Handle(command, CancellationToken.None);
   await queryService.Received().GetEquipAndItemAsync();
   await itemRepository.Received().ListAsync();
  }
}
