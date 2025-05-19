namespace SSZ.Web.MaintenanceItems;

public class CreateMaintenanceItemResponse(Guid Id, string name)
{
  public Guid Id { get; set; } = Id;
  public string Name { get; set; } = name;
}
