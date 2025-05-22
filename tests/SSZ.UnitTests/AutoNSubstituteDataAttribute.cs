using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using SSZ.UnitTests.UseCases.Maintenances;

namespace SSZ.UnitTests;

public class AutoNSubstituteDataAttribute : AutoDataAttribute
{
  public AutoNSubstituteDataAttribute()
    : base(() =>
    {
      var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
      //可在此处预设测试数据
      // fixture.Customize(new PastMaintenancePlanCustomization());
      return fixture;
    })
  {
  }
}
