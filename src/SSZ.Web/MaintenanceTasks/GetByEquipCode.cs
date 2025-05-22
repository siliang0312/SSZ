using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Web.MaintenanceTasks;

public class GetByEquipCode(IMediator mediator): Endpoint<GetByEquipCodeRequest, GetByEquipCodeResponse>
{
  public override void Configure()
  {
    Get(GetByEquipCodeRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary  = "根据设备编码获取设备下的任务";
      s.RequestParam(x=>x.EquipmentCode,"设备编码");
      s.RequestParam(x=>x.State,"任务状态");
      s.ExampleRequest = new GetByEquipCodeRequest { EquipmentCode = "ATQ001",State = TaskState.Waiting};
    });
  }
  public override async Task HandleAsync(
    GetByEquipCodeRequest request,
    CancellationToken cancellationToken)
  {
    var state = TaskState.FromValue(request.State);
    
    var response = new GetByEquipCodeResponse();
    response.Tasks = [];
    Response = response;
    // var result = await mediator.Send(new CreateContributorCommand(request.Name!,
    //   request.PhoneNumber), cancellationToken);
    //
    // if (result.IsSuccess)
    // {
    //   // Response = new CreateContributorResponse(result.Value, request.Name!);
    //   return;
    // }
  }
}
