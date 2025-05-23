using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Web.MaintenanceTasks;

public class GetByEquipCodeRequest
{
  public const string Route = "/MaintenanceTasks/{EquipmentCode}/{State}";

  public static string BuildRoute(string equipmentCode,int state)
    => Route
      .Replace("{EquipmentCode}", equipmentCode)
      .Replace("{State}", state.ToString());

  public string EquipmentCode { get; set; } 
  public int State { get; set; }
}
