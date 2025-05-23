namespace SSZ.UseCases.MaintenanceTasks;

public record SubmitTaskCommand(List<SubmitTaskDto> Tasks):ICommand<Result>;

public record SubmitTaskDto(Guid TaskId, Guid ImageId, int Duration, string Feedback);
