using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Specifications;

namespace SSZ.UseCases.MaintenanceTasks;

public class CreateMaintenanceTaskHandler(IRepository<MaintenancePlan> planRepository,
  IRepository<MaintenanceTask> taskRepository
):ICommandHandler<CreateMaintenanceTaskCommand,Result>
{
  public async Task<Result> Handle(CreateMaintenanceTaskCommand request, CancellationToken cancellationToken)
  {
    var plans=await planRepository.ListAsync(new PlanOverNextDateSpec(),cancellationToken);
    List<MaintenanceTask> tasks = [];
    foreach (var plan in plans)
    {
      var requestDate = DateTime.UtcNow.AddDays(3);
      var task = new MaintenanceTask(plan.EquipmentId,  plan.MaintenanceItemId,plan.Id,requestDate,DateTime.UtcNow );
      tasks.Add(task);
    }

    await taskRepository.AddRangeAsync(tasks, cancellationToken);
    return Result.Success();
  }
}
