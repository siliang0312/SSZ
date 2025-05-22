using MediatR;
using SSZ.UseCases.MaintenancePlans;
using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.FunctionalTests.Processors;

public class TaskProcessorTest(CustomWebApplicationFactory<Program> factory): IClassFixture<CustomWebApplicationFactory<Program>>
{
  [Fact]
  public async Task TaskGenerator_ShouldCorrect()
  {
    var scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();
    using var scope = scopeFactory.CreateScope();
    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
    var command = new CreateMaintenanceTaskCommand();
    var res= await mediator.Send(command);
    Assert.True(res.IsSuccess);
  }
}

