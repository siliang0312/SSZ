using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.UnitTests.Core.MaintenanceAggregate;

public class MaintenanceCycleTests
{
  private readonly DateTime _target=new DateTime(2025, 5, 20);
  [Fact]
  public void GetNextDate_IfDay_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Day,10);
    var nextDate = new DateTime(_target.Year, _target.Month, _target.Day + 10).Date;
    var res=cycle.GetNextDate(_target).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfMonthAndLessThanTarget_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Month,1);
    cycle.SetDayOfPeriod(1);
    var nextDate = new DateTime(_target.Year, _target.Month, 1).AddMonths(2).Date;
    var res=cycle.GetNextDate(_target).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfMonthAndGreaterThanTarget_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Month,1);
    cycle.SetDayOfPeriod(21);
    var nextDate = new DateTime(_target.Year, _target.Month, 21).AddMonths(1).Date;
    var res=cycle.GetNextDate(_target).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfMonthAndEqualTarget_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Month,1);
    cycle.SetDayOfPeriod(20);
    var nextDate = new DateTime(_target.Year, _target.Month, 20).AddMonths(1).Date;
    var res=cycle.GetNextDate(_target).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfWeekAndLessThanTarget_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Week,2);
    cycle.SetDayOfPeriod(1);
    var nextDate = _target.AddDays(7*2+ + 7-5+1).Date;
    var res=cycle.GetNextDate(_target).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfWeekAndGreaterThanTarget_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Week,2);
    cycle.SetDayOfPeriod(3);
    var nextDate = _target.AddDays(7*2+  1).Date;
    var res=cycle.GetNextDate(_target).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfWeekAndEqualTarget_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Week,2);
    cycle.SetDayOfPeriod(2);
    var nextDate = _target.AddDays(7*2).Date;
    var res=cycle.GetNextDate(_target).Date;
    Assert.Equal(nextDate, res);
  }
}
