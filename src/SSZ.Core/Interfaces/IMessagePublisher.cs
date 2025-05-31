namespace SSZ.Core.Interfaces;

public interface IMessagePublisher
{
  Task Publish(object applicationEvent);
}
