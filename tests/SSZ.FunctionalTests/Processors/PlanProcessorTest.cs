using MediatR;
using SSZ.UseCases.MaintenancePlans;

namespace SSZ.FunctionalTests.Processors;

public class PlanProcessorTest(CustomWebApplicationFactory<Program> factory): IClassFixture<CustomWebApplicationFactory<Program>>
{
  [Fact]
  public async Task PlanGenerator_ShouldCorrect()
  {
    var scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
    using var scope = scopeFactory.CreateScope();
    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
    var command = new CreateMaintenancePlanCommand();
   var res= await mediator.Send(command);
   Assert.True(res.IsSuccess);
  }
}
