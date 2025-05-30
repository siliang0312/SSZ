﻿using SSZ.Core.Interfaces;
using SSZ.Core.Services;
using SSZ.Infrastructure.Data;
using SSZ.Infrastructure.Data.Queries;
using SSZ.Infrastructure.Data.Repositories;
using SSZ.UseCases;
using SSZ.UseCases.Contributors.List;
using SSZ.UseCases.MaintenanceTasks;


namespace SSZ.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("SqliteConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseSqlite(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
           .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
           .AddScoped<IListContributorsQueryService, ListContributorsQueryService>()
           .AddScoped<IMaintenanceRepository, MaintenanceRepository>()
           .AddScoped<IDeleteContributorService, DeleteContributorService>()
           .AddScoped<IMaintenanceQueryService, MaintenanceQueryService>()
           .AddScoped<IMaintenanceTaskService, MaintenanceTaskService>();


    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
