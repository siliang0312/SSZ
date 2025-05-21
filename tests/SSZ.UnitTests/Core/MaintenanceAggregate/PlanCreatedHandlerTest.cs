using AutoFixture;
using AutoFixture.AutoNSubstitute;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Events;
using SSZ.Core.Aggregate.Maintenance.Handlers;

namespace SSZ.UnitTests.Core.MaintenanceAggregate;

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

public class PlanCreatedHandlerTests
{
  [Theory, AutoNSubstituteData]
  public async Task Handle_ShouldUpdatePlanNextDateTimeCorrectly(
    [Frozen] IRepository<MaintenancePlan> planRepo,
    [Frozen] IRepository<MaintenanceItem> itemRepo,
    [Frozen] ILogger<PlanCreatedHandler> logger,
    PlanCreatedEvent domainEvent,
    MaintenancePlan fakePlan,
    DateTime nextDate // 控制下一次维护日期
  )
  {
    // Arrange
    var cycleMock = Substitute.For<MaintenanceCycle>(MaintenanceCycleType.Day,1);
    cycleMock.GetNextDate(Arg.Any<DateTime>()).Returns(nextDate);
    var fakeItem = new MaintenanceItem("name", "content", Guid.NewGuid(),cycleMock);
    planRepo.GetByIdAsync(domainEvent.PlanId, Arg.Any<CancellationToken>())
      .Returns(fakePlan);

    itemRepo.GetByIdAsync(fakePlan.EquipmentId, Arg.Any<CancellationToken>())
      .Returns(fakeItem);

    var handler = new PlanCreatedHandler(logger, planRepo, itemRepo);

    // Act
    await handler.Handle(domainEvent, CancellationToken.None);

    // Assert
    Assert.Equal(nextDate.Date, fakePlan.NextDateTime);
    await planRepo.Received().UpdateAsync(fakePlan, Arg.Any<CancellationToken>());
    cycleMock.Received().GetNextDate(Arg.Any<DateTime>());
  }
}
