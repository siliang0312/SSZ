using FluentValidation;

namespace SSZ.Web.MaintenanceTasks;

public class GetByEquipCodeValidator:Validator<GetByEquipCodeRequest>
{
  public GetByEquipCodeValidator()
  {
    RuleFor(x => x.EquipmentCode)
      .NotEmpty();
    RuleFor(x => x.State).NotNull();
  }
}
