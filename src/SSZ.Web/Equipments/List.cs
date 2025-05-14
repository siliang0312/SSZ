using SSZ.UseCases.Equipments.List;

namespace SSZ.Web.Equipments;
/// <summary>
/// Equipment
/// </summary>
/// <param name="_mediator"></param>
public class List(IMediator _mediator) : Endpoint<EquipmentListRequest,EquipmentListResponse>
{
  public override void Configure()
  {
    Get(EquipmentListRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(EquipmentListRequest request, CancellationToken cancellationToken)
  {
    var query = new ListEquipmentQuery(request.Name,request.Code);
    var result = await _mediator.Send(query, cancellationToken);
   
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new EquipmentListResponse
      {
        Equipments =  result.Value.Select(a=>new EquipmentRecord(a.guid,a.Name,a.Code,a.ProductionLineGuid,a.ProductionLine)).ToList()
      };

    }
  }
}
