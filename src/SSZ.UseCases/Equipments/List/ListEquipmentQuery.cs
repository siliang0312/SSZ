namespace SSZ.UseCases.Equipments.List;

public record ListEquipmentQuery(string? Name, string? Code)
  : IQuery<Result<IEnumerable<EquipmentDto>>>;
