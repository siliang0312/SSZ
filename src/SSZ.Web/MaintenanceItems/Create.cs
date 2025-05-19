using Ardalis.SharedKernel;
using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Web.MaintenanceItems;

public class Create(IRepository<MaintenanceItem> repository)
  : Endpoint<CreateMaintenanceItemRequest, CreateMaintenanceItemResponse>
{
  public override void Configure()
  {
    Post(CreateMaintenanceItemRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateMaintenanceItemRequest {  };
    });
  }

  public override async Task HandleAsync(
    CreateMaintenanceItemRequest request,
    CancellationToken cancellationToken)
  {
    var cycle = new MaintenanceCycle(request.CycleType!,request.IntervalTime);
    
    if(request.DayOfPeriod.HasValue)cycle.SetDayOfPeriod(request.DayOfPeriod.Value);
    
    var maintenanceItem = new MaintenanceItem(request.Name!, request.Content!, request.EquipmentTypeId,cycle);
    var result = await repository.AddAsync(maintenanceItem, cancellationToken);
    Response = new CreateMaintenanceItemResponse(result.Id, request.Name!);
  }
}
