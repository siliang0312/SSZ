using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Events;
using SSZ.Core.Aggregate.Maintenance.Specifications;
using SSZ.Core.Interfaces;

namespace SSZ.Core.Services;

public class MaintenanceTaskService(IMediator mediator,IRepository<MaintenancePlan> planRepo):IMaintenanceTaskService
{
  public async Task ConfirmTask(List<Guid> planIds,List<Guid> taskIds)
  {
    var spec = new GetPlanByIdsSpec(planIds);
    var plans = await planRepo.ListAsync(spec);
    plans.ForEach(p=>p.UpdateLastDateTime());
    await planRepo.SaveChangesAsync();
    // 发布事件
    await mediator.Publish(new TaskConfirmedEvent(taskIds));
  }
}
