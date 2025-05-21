using SSZ.UseCases.MaintenancePlans;
using ILogger = Serilog.ILogger;

namespace SSZ.Web.Processor;

public class GenerateMaintenancePlanJob(ILogger<GenerateMaintenancePlanJob> logger,IServiceProvider serviceProvider): BackgroundService
{
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      logger.LogInformation("⏰ 开始执行保养计划生成任务...");
      var command = new CreateMaintenancePlanCommand();
      try
      {
        using var scope = serviceProvider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(command, stoppingToken);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        logger.LogError(e, "保养计划生成任务执行出错");
        // throw;
      } // 关键逻辑

      await Task.Delay(TimeSpan.FromHours(1), stoppingToken); // 间隔执行
    }
  }
}
