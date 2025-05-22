using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.Web.Processor;

public class GenerateMaintenanceTaskJob(ILogger<GenerateMaintenanceTaskJob> logger,IServiceProvider serviceProvider): BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      logger.LogInformation("⏰ 开始执行保养任务生成任务...");
      var command = new CreateMaintenanceTaskCommand();
      try
      {
        using var scope = serviceProvider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(command, stoppingToken);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        logger.LogError(e, "保养任务生成任务执行出错");
        // throw;
      } // 关键逻辑

      await Task.Delay(TimeSpan.FromHours(1), stoppingToken); // 间隔执行
    }
  }
}
