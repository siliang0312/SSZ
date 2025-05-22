using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Events;
using SSZ.Core.Aggregate.Maintenance.Handlers;

namespace SSZ.UnitTests.Core.MaintenanceAggregate;

public class TaskCreatedHandlerTest
{
  [Theory, AutoNSubstituteData]
  public async Task Handle_ShouldSaveSuccess(
    [Frozen] IRepository<MaintenancePlan> planRepository,
    ILogger<TaskCreatedHandler> logger,
    // [Frozen] IRepository<MaintenanceTask> taskRepository,
    IEnumerable<MaintenancePlan> plans,
    TaskCreatedEvent domainEvent,
    MaintenancePlan fakePlan
  )
  {
    planRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(fakePlan);
    var handler = new TaskCreatedHandler(planRepository,logger);
    await handler.Handle(domainEvent, CancellationToken.None);
    Assert.Equal(DateTime.MaxValue, fakePlan.NextDateTime);
   await planRepository.Received().GetByIdAsync(Arg.Any<Guid>());
   await planRepository.Received().SaveChangesAsync();
  }
}
