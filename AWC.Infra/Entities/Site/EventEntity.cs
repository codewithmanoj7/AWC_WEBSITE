using AWC.Infra.Bases;

namespace AWC.Infra.Entities.Site;

public class EventEntity : BaseEntity
{
    public DateTime Date { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Location { get; set; }
    // Time properties (stored as TimeSpan in database)
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    // String representations for form binding
    public string StartTimeString
    {
        get => StartTime.HasValue ? new TimeOnly(StartTime.Value.Ticks).ToString("HH:mm") : null;
        set => StartTime = string.IsNullOrEmpty(value) ? null : TimeOnly.Parse(value).ToTimeSpan();
    }

    public string EndTimeString
    {
        get => EndTime.HasValue ? new TimeOnly(EndTime.Value.Ticks).ToString("HH:mm") : null;
        set => EndTime = string.IsNullOrEmpty(value) ? null : TimeOnly.Parse(value).ToTimeSpan();
    }
    public string? Description { get; set; }
    public int? MaxAttendees { get; set; }
    public bool RegistrationRequired { get; set; }
    public bool IsActive { get; set; } = true;
    public string? ImageUrl { get; set; }
    public string? ExternalUrl { get; set; }
}