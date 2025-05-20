using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.UnitTests.Core.MaintenanceAggregate;

public class MaintenanceCycleTests
{
  private readonly DateTime _now=DateTime.UtcNow;
  [Fact]
  public void GetNextDate_IfDay_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Day,10);
    var nextDate = new DateTime(_now.Year, _now.Month, _now.Day + 10).Date;
    var res=cycle.GetNextDate(_now).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfMonthAndLessThanNow_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Month,1);
    cycle.SetDayOfPeriod(1);
    var nextDate = new DateTime(_now.Year, _now.Month, 1).AddMonths(2).Date;
    var res=cycle.GetNextDate(_now).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfMonthAndGreaterThanNow_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Month,1);
    cycle.SetDayOfPeriod(21);
    var nextDate = new DateTime(_now.Year, _now.Month, 21).AddMonths(1).Date;
    var res=cycle.GetNextDate(_now).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfMonthAndEqualNow_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Month,1);
    cycle.SetDayOfPeriod(20);
    var nextDate = new DateTime(_now.Year, _now.Month, 20).AddMonths(1).Date;
    var res=cycle.GetNextDate(_now).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfWeekAndLessThanNow_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Week,2);
    cycle.SetDayOfPeriod(1);
    var nextDate = _now.AddDays(7*2+ + 7-5+1).Date;
    var res=cycle.GetNextDate(_now).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfWeekAndGreaterThanNow_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Week,2);
    cycle.SetDayOfPeriod(3);
    var nextDate = _now.AddDays(7*2+  1).Date;
    var res=cycle.GetNextDate(_now).Date;
    Assert.Equal(nextDate, res);
  }
  [Fact]
  public void GetNextDate_IfWeekAndEqualNow_ReturnsNextDay()
  {
    var cycle = new MaintenanceCycle(MaintenanceCycleType.Week,2);
    cycle.SetDayOfPeriod(2);
    var nextDate = _now.AddDays(7*2).Date;
    var res=cycle.GetNextDate(_now).Date;
    Assert.Equal(nextDate, res);
  }
}
