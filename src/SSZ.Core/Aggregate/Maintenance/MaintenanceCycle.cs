namespace SSZ.Core.Aggregate.Maintenance;

public class MaintenanceCycle(MaintenanceCycleType cycleType, int intervalTime):ValueObject
{
  public MaintenanceCycleType CycleType { get; private set; }=Guard.Against.Null(cycleType);
  public int IntervalTime { get; private set; } = Guard.Against.NegativeOrZero(intervalTime);
  public int DayOfPeriod { get; private set; } = 0;
  public void SetDayOfPeriod(int dayOfPeriod)
  {
    DayOfPeriod = Guard.Against.NegativeOrZero(dayOfPeriod);
  }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return CycleType;
    yield return IntervalTime;
    yield return DayOfPeriod;
  }
}
