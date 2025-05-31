using Ardalis.Specification;
using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Equipment;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Exceptions;
using SSZ.UseCases.MessageHandlers;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class EquipStateChangedEventTests
{
  [Theory,AutoNSubstituteData]
  public async Task Handle_ShouldConsumeEvent(
    [Frozen] IRepository<MaintenancePlan> repository,
    EquipStateChangedConsumer handler)
  {
    repository.ListAsync(Arg.Any<ISpecification<MaintenancePlan>>()).Returns([]);
    var integrationEvent = new EquipStateChangedIntegrationEvent(default, default);
    await handler.Consume(integrationEvent);
    await repository.Received(1).ListAsync(Arg.Any<ISpecification<MaintenancePlan>>());
    await repository.Received(1).SaveChangesAsync();
  }
  
  [Theory,AutoNSubstituteData]
  public async Task Handle_IfStateIsStop_PlanStateShouldEqualFalse(
   [Frozen] IRepository<MaintenancePlan> repository,
   MaintenancePlan plan,
   EquipStateChangedConsumer handler)
  {
    repository.ListAsync(Arg.Any<ISpecification<MaintenancePlan>>()).Returns([plan]);
    var integrationEvent = new EquipStateChangedIntegrationEvent(Guid.NewGuid(), EquipmentStatus.Stop);
    await handler.Consume(integrationEvent);
    Assert.False(plan.IsActive);
  }
  
  [Theory,AutoNSubstituteData]
  public async Task Handle_IfStateIsNormal_PlanStateShouldEqualTrue(
    [Frozen] IRepository<MaintenancePlan> repository,
    MaintenancePlan plan,
    EquipStateChangedConsumer handler)
  {
    repository.ListAsync(Arg.Any<ISpecification<MaintenancePlan>>()).Returns([plan]);
    var integrationEvent = new EquipStateChangedIntegrationEvent(Guid.NewGuid(), EquipmentStatus.Normal);
    await handler.Consume(integrationEvent);
    Assert.True(plan.IsActive);
  }
  [Theory,AutoNSubstituteData]
  public async Task Handle_IfStateIsUnsupported_ShouldThrowException(
    [Frozen] IRepository<MaintenancePlan> repository,
    MaintenancePlan plan,
    EquipStateChangedConsumer handler)
  {
    repository.ListAsync(Arg.Any<ISpecification<MaintenancePlan>>()).Returns([plan]);
    var integrationEvent = new EquipStateChangedIntegrationEvent(Guid.NewGuid(), EquipmentStatus.Idle);
   var exception=await Assert.ThrowsAsync<MaintenanceException>(()=>handler.Consume(integrationEvent))  ;
    Assert.Equal("Unsupported equipment status: Idle", exception.Message);
  }
}
