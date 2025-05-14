namespace SSZ.Web.Equipments;

public class EquipmentListRequest
{
  public const string Route = "/Equipments";

  public string? Name { get; set; }
  public string? Code { get; set; }
}
