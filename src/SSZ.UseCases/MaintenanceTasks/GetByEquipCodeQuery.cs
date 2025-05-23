namespace SSZ.UseCases.MaintenanceTasks;

public record GetByEquipCodeQuery(string EquipmentCode, int State):  IQuery<Result<IEnumerable<MaintenanceTaskDto>>>;
