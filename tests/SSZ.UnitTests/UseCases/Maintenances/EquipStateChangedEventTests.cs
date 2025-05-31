using SSZ.UseCases.MessageHandlers;

namespace SSZ.UnitTests.UseCases.Maintenances;

public class EquipStateChangedEventTests
{
  [Fact]
  public async Task Handle_ShouldConsumeEvent()
  {
    var handler = new EquipStateChangedConsumer();
    var integrationEvent = new EquipStateChangedIntegrationEvent("EQUIP123", "Stop");
    await handler.Consume(integrationEvent);
  }
}
