

using SSZ.Processor;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<PlanService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
using (var serviceScope= app.Services.CreateScope())
{
  var services = serviceScope.ServiceProvider;

  var planService = services.GetRequiredService<PlanService>();
  await planService.GeneratePlans();
}
app.Run();
