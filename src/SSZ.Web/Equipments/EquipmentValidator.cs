using FluentValidation;
using SSZ.Infrastructure.Data.Config;

namespace SSZ.Web.Equipments;

public class EquipmentValidator : Validator<EquipmentListRequest>
{
  public EquipmentValidator()
  {
    RuleFor(e=>e.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }

}
