using FluentValidation;
using SSZ.Web.Contributors;

namespace SSZ.Web.MaintenanceItems;

public class CreateMaintenanceItemValidator:Validator<CreateMaintenanceItemRequest>
{
  public CreateMaintenanceItemValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty();
    RuleFor(x => x.CycleType)
      .NotEmpty();
    RuleFor(x => x.Content)
      .NotEmpty();
  }
}
