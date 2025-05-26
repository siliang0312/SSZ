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
    MaintenanceTask[] maintenanceTasks = [task];
    taskRepository
      .ListAsync(Arg.Any<ISpecification<MaintenanceTask>>(), Arg.Any<CancellationToken>())
      .Returns(maintenanceTasks.ToList());
    var handler = new ConfirmTaskHandler(taskService,taskRepository);
    
    await handler.Handle(command, CancellationToken.None);
    
    await taskRepository.Received()
      .ListAsync(Arg.Any<ISpecification<MaintenanceTask>>(), Arg.Any<CancellationToken>());
    await taskRepository.Received().SaveChangesAsync();
    await taskService.Received().ConfirmTask(Arg.Any<List<MaintenanceTask>>());
  }
  
  [Theory, AutoNSubstituteData]
  public async Task Handle_WhenPass_SateShouldConfirm(
    [Frozen]IRepository<MaintenanceTask>  taskRepository,
    [Frozen]IMaintenanceTaskService  taskService,
    ConfirmTaskCommand command,
    MaintenanceTask task)
  {
    task.Id=command.Tasks.First().TaskId;
    for (int i = 0; i < command.Tasks.Count; i++)
    {
      var newTask = command.Tasks[i] with { IsPassed = true };
      command.Tasks[i] = newTask;
    }

    MaintenanceTask[] maintenanceTasks = [task];
    task.MarkSubmitted(Guid.NewGuid(),  1,"测试");
    taskRepository
      .ListAsync(Arg.Any<ISpecification<MaintenanceTask>>(), Arg.Any<CancellationToken>())
      .Returns(maintenanceTasks.ToList());
    
    var handler = new ConfirmTaskHandler(taskService,taskRepository);
    
    await handler.Handle(command, CancellationToken.None);
    
   
    Assert.All(maintenanceTasks, a => Assert.Equal(a.State, TaskState.Confirmed));
  }
  
  [Theory, AutoNSubstituteData]
  public async Task Handle_WhenNotPass_SateShouldSubmitted(
    [Frozen]IRepository<MaintenanceTask>  taskRepository,
    [Frozen]IMaintenanceTaskService  taskService,
    ConfirmTaskCommand command,
    MaintenanceTask task)
  {
    task.Id=command.Tasks.First().TaskId;
    for (int i = 0; i < command.Tasks.Count; i++)
    {
      var newTask = command.Tasks[i] with { IsPassed = false };
      command.Tasks[i] = newTask;
    }

    MaintenanceTask[] maintenanceTasks = [task];
    task.MarkSubmitted(Guid.NewGuid(),  1,"测试");
    taskRepository
      .ListAsync(Arg.Any<ISpecification<MaintenanceTask>>(), Arg.Any<CancellationToken>())
      .Returns(maintenanceTasks.ToList());
    
    var handler = new ConfirmTaskHandler(taskService,taskRepository);
    
    await handler.Handle(command, CancellationToken.None);
    
   
    Assert.All(maintenanceTasks, a => Assert.Equal(a.State, TaskState.Waiting));
  }
}
