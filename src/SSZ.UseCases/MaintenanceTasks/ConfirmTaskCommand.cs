namespace SSZ.UseCases.MaintenanceTasks;

public record ConfirmTaskCommand(List<ConfirmTaskDto> Tasks) : ICommand<Result>;


public record ConfirmTaskDto(Guid TaskId, string AuditOpinion,bool IsPassed);
