namespace SSZ.Core.Aggregate.Maintenance;

public class TaskState:SmartEnum<TaskState>
{
  public static readonly TaskState Waiting = new(nameof(Waiting), 1);
  public static readonly TaskState Submitted = new(nameof(Submitted), 2);
  public static readonly TaskState Confirmed = new(nameof(Confirmed), 3);
  public TaskState(string name, int value) : base(name, value)
  {
  }
}
