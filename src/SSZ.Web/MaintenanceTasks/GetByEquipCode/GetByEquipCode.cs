using SSZ.Core.Aggregate.Maintenance;
using SSZ.UseCases.MaintenanceTasks;

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
      s.ExampleRequest = new GetByEquipCodeRequest { EquipmentCode = "ATQ001",State = TaskState.Waiting.Value};
    });
  }
  public override async Task HandleAsync(
    GetByEquipCodeRequest request,
    CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new GetByEquipCodeQuery(request.EquipmentCode,
      request.State), cancellationToken);
    
    if (result.IsSuccess)
    {
      Response = new GetByEquipCodeResponse()
      {
        Tasks =  result.Value.Select(a=>new TaskRecord(a.TaskId,a.ItemId,a.ItemContent??string.Empty,a.ItemName??string.Empty,a.Duration,a.Feedback,a.ImageId)).ToList()
      };
    }
  }
}
