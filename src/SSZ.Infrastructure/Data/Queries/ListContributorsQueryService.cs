using SSZ.UseCases.Contributors;
using SSZ.UseCases.Contributors.List;

namespace SSZ.Infrastructure.Data.Queries;

public class ListContributorsQueryService(AppDbContext _db) : IListContributorsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    // var result = await _db.Database.SqlQuery<ContributorDTO>(
    //     $"SELECT Id, Name,PhoneNumber_Number AS PhoneNumber FROM Contributors") // don't fetch other big columns
    //   .ToListAsync();
    var result =await _db.Contributors
      .Select(a => new ContributorDTO(a.Id,a.Name,a.PhoneNumber!.Number))
      .ToListAsync();
    return result;
  }
}
