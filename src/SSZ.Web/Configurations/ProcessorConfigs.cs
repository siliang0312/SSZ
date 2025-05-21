using SSZ.Web.Processor;

namespace SSZ.Web.Configurations;

public static class ProcessorConfigs
{
  public static WebApplicationBuilder AddProcessorConfigs(this WebApplicationBuilder builder)
  {

    builder.Services.AddHostedService<GenerateMaintenancePlanJob>();

    return builder;
  }
}
