using EFCore.BulkExtensions;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Dtos;
using SSZ.UseCases.MaintenancePlans;

namespace SSZ.Infrastructure.Data.Repositories;

public class MaintenanceRepository(AppDbContext context,ILogger<MaintenanceRepository> logger):IMaintenanceRepository
{
  public async Task<IEnumerable<EquipAndItemDto>> GetEquipAndItemAsync()
  {
    logger.LogInformation("获取设备及维护项Guid");

    var res =from equip in context.Equipments.AsNoTracking()
      join item in context.MaintenanceItems.AsNoTracking() 
        on equip.EquipmentTypeId equals item.EquipmentTypeId
      select new EquipAndItemDto(equip.Id,item.Id);
     return await  res.ToListAsync();
  }

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
    //TODO:由于此处采用了BulkExtensions, 不使用ChangeTracker，导致领域事件失效待解决
     await context.BulkInsertOrUpdateAsync(plans, bulkConfig);
  }
}
