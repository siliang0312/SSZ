using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Web.MaintenanceItems;

public class CreateMaintenanceItemRequest
{
  public const string Route = "/MaintenanceItems";
  [Required]
  public string? Name { get; set; }
  public string? Content { get; set; }
  public Guid EquipmentTypeId { get; set; }
  [JsonConverter(typeof(SmartEnumNameConverter<MaintenanceCycleType, int>))]
  public MaintenanceCycleType CycleType { get; set; }=MaintenanceCycleType.Day;
  public int IntervalTime { get; set; }
  public int? DayOfPeriod { get; set; }
}
