using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Specifications;
using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class SubmitTaskHandlerTest
{
  [Theory, AutoNSubstituteData]
  public async Task Handle_ShouldSaveSuccess(
    [Frozen]IRepository<MaintenanceTask> repository,
    MaintenanceTask task,
    SubmitTaskCommand command)
  {
    task.Id= command.Tasks.First().TaskId;
    List<MaintenanceTask> maintenanceTasks = [task];
    repository.ListAsync(Arg.Any<GetTasksByIdsSpec>(), Arg.Any<CancellationToken>())
      .Returns(maintenanceTasks.ToList());
    
    var handler = new SubmitTaskHandler(repository);
   await handler.Handle(command, CancellationToken.None);
   
  await repository.Received()
    .ListAsync(Arg.Any<GetTasksByIdsSpec>(), Arg.Any<CancellationToken>());

  await repository.Received().SaveChangesAsync();
  Assert.All(maintenanceTasks, t => Assert.Equal(TaskState.Submitted, t.State));

  }
}
