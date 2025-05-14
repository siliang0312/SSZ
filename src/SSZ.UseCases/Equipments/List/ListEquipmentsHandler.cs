using SSZ.Core.Aggregate.Equipment;
using SSZ.Core.Aggregate.Equipment.Specifications;

namespace SSZ.UseCases.Equipments.List;

public class ListContributorsHandler(IReadRepository<Equipment> _repository)
  : IQueryHandler<ListEquipmentQuery, Result<IEnumerable<EquipmentDto>>>
{
  public async Task<Result<IEnumerable<EquipmentDto>>> Handle(ListEquipmentQuery request, CancellationToken cancellationToken)
  {
    var spec = new EquipmentBySearchSpec(request.Name, request.Code);
    var result = await _repository.ListAsync(spec, cancellationToken);
      
    return Result.Success(result.Select(a=>new EquipmentDto(a.Id,a.Name,a.Code,a.ProductionLineGuid,string.Empty)));
    
  }
}
