using Ardalis.Specification;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Events;
using SSZ.Core.Services;

namespace SSZ.UnitTests.Core.Services;

public class MaintenanceTaskServiceTest
{
  [Theory,  AutoNSubstituteData]
  public async Task ConfirmTask_ShouldUpdate_PlanLastDate(
    IMediator mediator,
    IRepository<MaintenancePlan> planRepo,
    IEnumerable<MaintenancePlan> plans,
    IEnumerable<Guid> taskIds
    )
  {
    var maintenancePlans = plans as MaintenancePlan[] ?? plans.ToArray();
    planRepo.ListAsync(Arg.Any<ISpecification<MaintenancePlan>>(), Arg.Any<CancellationToken>())
      .Returns(maintenancePlans.ToList());
    var planIds=  maintenancePlans.Select(x=>x.Id).ToList();
    var service = new MaintenanceTaskService(mediator,planRepo);
    await service.ConfirmTask(planIds,taskIds.ToList());
  await  planRepo.Received().ListAsync(Arg.Any<ISpecification<MaintenancePlan>>(), Arg.Any<CancellationToken>());
   await planRepo.Received().SaveChangesAsync();
   
    Assert.All(maintenancePlans,a=>Assert.Equal(DateTime.UtcNow.Date,a.LastDateTime));
   await mediator.Received().Publish(Arg.Any<TaskConfirmedEvent>());
  }
}
