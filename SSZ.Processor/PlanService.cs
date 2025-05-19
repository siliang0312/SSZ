using System.Data.SQLite;
using Dapper;
using Z.Dapper.Plus;

namespace SSZ.Processor;

public class PlanService(IConfiguration configuration,ILogger<PlanService> logger)
{
  public async Task GeneratePlans()
  {
    logger.LogInformation("Start Generate Plans");
    using (var connection = new SQLiteConnection(configuration["ConnectionStrings:SqliteConnection"]))
    {
      var sql = @$"SELECT * FROM MaintenanceItems;
                    SELECT * FROM Equipments;";     
      var items = await connection.QueryMultipleAsync(sql);
      var maintenanceItems =(await items.ReadAsync()).ToList();
      var equipments = (await items.ReadAsync()).ToList();
      foreach (var equipment in equipments)
      {
        
      }
     // await connection.BulkInsertAsync(items);
    }
      
    logger.LogInformation("End Generate Plans");
  }
}
