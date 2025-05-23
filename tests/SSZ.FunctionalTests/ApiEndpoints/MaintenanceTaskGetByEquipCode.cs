using SSZ.Web.MaintenanceTasks;

namespace SSZ.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class MaintenanceTaskGetByEquipCode(CustomWebApplicationFactory<Program> factory):IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task When_ReturnsNoData()
  {
  var result=  await _client.GetAndDeserializeAsync<GetByEquipCodeResponse>(GetByEquipCodeRequest.BuildRoute("1",1));
    Assert.Empty(result.Tasks);
  }
}
