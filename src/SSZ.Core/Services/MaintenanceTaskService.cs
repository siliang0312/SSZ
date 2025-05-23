using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Events;
using SSZ.Core.Aggregate.Maintenance.Specifications;
using SSZ.Core.Interfaces;

namespace SSZ.Core.Services;

public class MaintenanceTaskService(IMediator mediator,IRepository<MaintenancePlan> planRepo):IMaintenanceTaskService
{
  public async Task ConfirmTask(List<MaintenanceTask> tasks)
  {
    var spec = new GetPlanByIdsSpec(tasks.Select(a=>a.MaintenancePlanId).ToList());
    var plans = await planRepo.ListAsync(spec);
    plans.ForEach(p=>p.UpdateLastDateTime());
    await planRepo.SaveChangesAsync();
    // 发布事件
    await mediator.Publish(new TaskConfirmedEvent(tasks));
  }
}
