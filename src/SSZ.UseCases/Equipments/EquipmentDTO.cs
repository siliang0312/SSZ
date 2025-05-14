namespace SSZ.UseCases.Equipments;

public record EquipmentDto(Guid guid, string Name, string Code, Guid ProductionLineGuid,string? ProductionLine);
