namespace SSZ.Web.MaintenanceTasks;

public record TaskRecord(Guid TaskId, Guid ItemId, string ItemContent, string ItemName, int Duration, string? Feedback, Guid ImageId);
