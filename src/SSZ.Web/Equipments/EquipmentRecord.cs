namespace SSZ.Web.Equipments;

public record EquipmentRecord(Guid guid, string Name, string Code, Guid ProductionLineGuid,string? ProductionLine);
