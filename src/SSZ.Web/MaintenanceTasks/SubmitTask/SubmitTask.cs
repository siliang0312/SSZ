using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.Web.MaintenanceTasks.SubmitTask;

public class SubmitTask(IMediator mediator):  Endpoint<SubmitTaskRequest>
{
  public override void Configure()
  {
    Post(SubmitTaskRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(SubmitTaskRequest req, CancellationToken ct)
  {
    var command = new SubmitTaskCommand(req.Tasks.Select(a=>new SubmitTaskDto(a.TaskId,a.ImageId,a.Duration,a.Feedback)).ToList());
    await mediator.Send(command, ct);
  }
}
