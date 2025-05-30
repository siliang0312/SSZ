﻿using SSZ.Core.Aggregate.Maintenance;
using SSZ.UseCases;
using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.Infrastructure.Data.Queries;

public class MaintenanceQueryService(AppDbContext context):IMaintenanceQueryService
{
  public async Task<IEnumerable<MaintenanceTaskDto>> GetTaskByEquipCode(string equipmentCode, int state)
  {
    var realState = TaskState.FromValue(state);
    var result = from t in context.MaintenanceTasks
      join e in context.Equipments
        on t.EquipmentId equals e.Id
      join i in context.MaintenanceItems
        on t.MaintenanceItemId equals i.Id into item
      from i in item.DefaultIfEmpty()
      where e.Code == equipmentCode && t.State==realState
      select new MaintenanceTaskDto
      {
        TaskId=t.Id,
        Duration = t.Duration,
        ItemName = i.Name,
        ItemContent = i.Content,
        ItemId = i.Id,
        Feedback=t.Feedback,
      };
    return await result.ToListAsync();
  }
  public async Task<IEnumerable<EquipAndItemDto>> GetEquipAndItemAsync()
  {

    var res =from equip in context.Equipments.AsNoTracking()
      join item in context.MaintenanceItems.AsNoTracking() 
        on equip.EquipmentTypeId equals item.EquipmentTypeId
      select new EquipAndItemDto(equip.Id,item.Id);
    return await  res.ToListAsync();
  }
}
