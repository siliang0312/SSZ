using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Web.MaintenanceItems;

public record MaintenanceItemRecord(Guid Id,string Name,string Content,string EquipmentType
  , Guid EquipmentTypeId, MaintenanceCycleType CycleType, int IntervalTime,int DayOfPeriod);
