namespace SSZ.UseCases.MaintenanceTasks;

public class MaintenanceTaskDto
{
  public Guid TaskId { get; set; }
  public Guid ItemId { get; set; }
  public string ItemContent { get; set; }
  public string ItemName { get; set; }
  public int Duration { get; set; }
  public string? Feedback { get; set; }
  public Guid ImageId { get; set; }
}
