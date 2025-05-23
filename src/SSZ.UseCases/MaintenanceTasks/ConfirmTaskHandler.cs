using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Specifications;
using SSZ.Core.Interfaces;

namespace SSZ.UseCases.MaintenanceTasks;

public class ConfirmTaskHandler(IMaintenanceTaskService taskService,IRepository<MaintenanceTask> taskRepo): ICommandHandler<ConfirmTaskCommand,Result>
{
  public async Task<Result> Handle(ConfirmTaskCommand request, CancellationToken cancellationToken)
  {
    var taskIds=request.Tasks.Select(a=>a.TaskId).ToList();
    var taskDict = request.Tasks.ToDictionary(a => a.TaskId, a => a);
    var tasksInDb = await taskRepo.ListAsync(new GetTasksByIdsSpec(taskIds),cancellationToken);
    foreach (var task in tasksInDb)
    {
      if (!taskDict.TryGetValue(task.Id, out var value))
        continue;

      if(value.IsPassed)task.MarkConfirmed();
      else task.Reject(value.AuditOpinion);
    }

    await taskRepo.SaveChangesAsync(cancellationToken);
    await taskService.ConfirmTask(tasksInDb);
    return Result.Success();
  }
}
