using MassTransit;
using SSZ.Core.Interfaces;
using SSZ.Infrastructure.Messaging;

namespace SSZ.Web.Configurations;

public static class MessageConfig
{
  public static void AddMessageConfigs(this IServiceCollection services, IConfiguration configuration)
  {
    var messagingConfig = configuration.GetSection("RabbitMq");
    services.Configure<RabbitMqConfiguration>(messagingConfig);
    services.AddScoped<IMessagePublisher, MassTransitMessagePublisher>();

    services.AddMassTransit(x =>
    {
      var rabbitMqConfiguration = messagingConfig.Get<RabbitMqConfiguration>();
      x.SetKebabCaseEndpointNameFormatter();

      x.UsingRabbitMq((context, cfg) =>
      {
        var port = (ushort)rabbitMqConfiguration.Port;
        cfg.Host(rabbitMqConfiguration.Hostname, port, rabbitMqConfiguration.VirtualHost, h =>
        {
          h.Username(rabbitMqConfiguration.UserName);
          h.Password(rabbitMqConfiguration.Password);
        });

        cfg.ConfigureEndpoints(context);
      });
    });
  }
}
