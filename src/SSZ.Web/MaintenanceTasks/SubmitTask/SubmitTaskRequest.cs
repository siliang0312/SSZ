namespace SSZ.Web.MaintenanceTasks.SubmitTask;

public class SubmitTaskRequest
{
  public const string Route = "/MaintenanceTasks/Submit";
  public List<SubmitTaskViewModel> Tasks { get; set; } = [];
}

public class SubmitTaskViewModel
{
  public Guid  TaskId { get; set; }
  public Guid  ImageId { get; set; }
  public int  Duration { get; set; }
  public string Feedback { get; set; } = string.Empty;
}
