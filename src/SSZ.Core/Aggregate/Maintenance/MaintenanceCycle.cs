using System.Diagnostics;

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
  
  public virtual DateTime GetNextDate(DateTime startDate)
  {

    if (CycleType == MaintenanceCycleType.Day)
    {
      return startDate.AddDays(IntervalTime);
    }
    if (CycleType == MaintenanceCycleType.Month)
    {
      var nextDate = new DateTime(startDate.Year,  startDate.Month, DayOfPeriod).AddMonths(1);
      return startDate.Day <= DayOfPeriod ?  nextDate: nextDate.AddMonths(1);
    }
    if(CycleType == MaintenanceCycleType.Week)
    {
      var dayOfWeek=  (int)startDate.DayOfWeek;
      var diff = DayOfPeriod -dayOfWeek;
      return startDate.AddDays(IntervalTime * 7).AddDays(diff < 0 ? dayOfWeek+DayOfPeriod : diff);
    }
    return DateTime.UtcNow;
  }
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return CycleType;
    yield return IntervalTime;
    yield return DayOfPeriod;
  }
}
