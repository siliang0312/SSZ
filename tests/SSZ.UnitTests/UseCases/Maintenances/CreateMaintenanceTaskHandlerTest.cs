using Ardalis.Specification;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Specifications;
using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class CreateMaintenanceTaskHandlerTest
{
  [Theory, AutoNSubstituteData]
  public async Task Handle_ShouldSaveSuccess(
    [Frozen] IRepository<MaintenancePlan> planRepository,
    [Frozen] IRepository<MaintenanceTask> taskRepository,
    IEnumerable<MaintenancePlan> plans,
    CreateMaintenanceTaskCommand command)
  {
    planRepository.ListAsync(Arg.Any<PlanOverNextDateSpec>(),  Arg.Any<CancellationToken>()).Returns(plans.ToList());
    var handler = new CreateMaintenanceTaskHandler(planRepository,taskRepository);
    await handler.Handle(command,  CancellationToken.None);
    
   await planRepository.Received().ListAsync(Arg.Any<PlanOverNextDateSpec>(),  Arg.Any<CancellationToken>());
  await  taskRepository.Received().AddRangeAsync(Arg.Any<List<MaintenanceTask>>(),Arg.Any<CancellationToken>());
  }
}
