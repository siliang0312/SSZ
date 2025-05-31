using SSZ.Core.Aggregate.Equipment;

namespace SSZ.UseCases.MessageHandlers;

public record EquipStateChangedIntegrationEvent(Guid EquipId, EquipmentStatus State);
