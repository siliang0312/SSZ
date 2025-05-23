using FluentValidation;

namespace SSZ.Web.MaintenanceTasks.SubmitTask;

public class SubmitTaskValidator:Validator<SubmitTaskRequest>
{
  public SubmitTaskValidator()
  {
    RuleForEach(x => x.Tasks)
      .ChildRules(task =>
      {
        task.RuleFor(t => t.Feedback)
          .NotEmpty().WithMessage("反馈不能为空");

      });
  }
}
