using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Specifications;

namespace SSZ.UseCases.MaintenanceTasks;

public class SubmitTaskHandler(IRepository<MaintenanceTask> taskRepo): ICommandHandler<SubmitTaskCommand,Result>
{
  public async Task<Result> Handle(SubmitTaskCommand request, CancellationToken cancellationToken)
  {
    var spec = new GetTasksByIdsSpec(request.Tasks.Select(x=>x.TaskId).ToList());
    var taskDict = request.Tasks.ToDictionary(t => t.TaskId);
    var tasksInDb=  await taskRepo.ListAsync(spec,cancellationToken);
    foreach (var data in tasksInDb)
    {
      if (taskDict.TryGetValue(data.Id, out var task))
        data.MarkSubmitted(task.ImageId, task.Duration, task.Feedback);
    }
    await taskRepo.SaveChangesAsync(cancellationToken);
    return Result.Success();
  }
}
