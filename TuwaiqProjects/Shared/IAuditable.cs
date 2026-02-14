namespace TuwaiqProjects.Shared;

public interface IAuditable
{
    long CreatedBy { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime LastModifiedAt { get; set; }

}