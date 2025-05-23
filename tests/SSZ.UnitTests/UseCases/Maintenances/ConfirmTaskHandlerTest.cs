using Ardalis.Specification;
using AutoFixture.Xunit2;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Interfaces;
using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class ConfirmTaskHandlerTest
{
  [Theory, AutoNSubstituteData]
  public async Task Handle_ShouldSaveSuccess(
    [Frozen]IRepository<MaintenanceTask>  taskRepository,
    [Frozen]IMaintenanceTaskService  taskService,
    ConfirmTaskCommand command,
    MaintenanceTask task)
  {
    task.Id=command.Tasks.First().TaskId;
    MaintenanceTask[] maintenanceTasks = [task];
    task.MarkSubmitted(Guid.NewGuid(),  1,"测试");
    taskRepository
      .ListAsync(Arg.Any<ISpecification<MaintenanceTask>>(), Arg.Any<CancellationToken>())
      .Returns(maintenanceTasks.ToList());
    
    
    var handler = new ConfirmTaskHandler(taskService,taskRepository);
    
    
    await handler.Handle(command, CancellationToken.None);
    
    await taskRepository.Received()
      .ListAsync(Arg.Any<ISpecification<MaintenanceTask>>(), Arg.Any<CancellationToken>());
    await taskRepository.Received().SaveChangesAsync();
    Assert.All(maintenanceTasks, a => Assert.NotEqual(a.State, TaskState.Submitted));
    await taskService.Received().ConfirmTask(Arg.Any<List<MaintenanceTask>>());
  }
}
