using MassTransit;
using SSZ.Core.Interfaces;

namespace SSZ.Infrastructure.Messaging;

public class MassTransitMessagePublisher(IPublishEndpoint publishEndpoint):IMessagePublisher
{
  private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
  public Task Publish(object applicationEvent)
  {
    Guard.Against.Null(applicationEvent);
    return _publishEndpoint.Publish(applicationEvent);
  }
}
