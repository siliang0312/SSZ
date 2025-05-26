using EFCore.BulkExtensions;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Interfaces;
using SSZ.UseCases.MaintenancePlans;
using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.Infrastructure.Data.Repositories;

public class MaintenanceRepository(AppDbContext context,ILogger<MaintenanceRepository> logger):IMaintenanceRepository
{


  public async Task InsertPlans(List<MaintenancePlan> plans)
  {
    var bulkConfig = new BulkConfig
    {
      // 设置用于匹配的字段（联合唯一键）
      UpdateByProperties = ["EquipmentId", "MaintenanceItemId"],
    
      // 可选配置（提高性能）
      PreserveInsertOrder = true,
      SetOutputIdentity = true
    };
    //由于此处采用了BulkExtensions, 不使用ChangeTracker，导致领域事件失效,所以取消了领域事件
     await context.BulkInsertOrUpdateAsync(plans, bulkConfig);
  }
}
