namespace Domain.Entities;

using Domain.Common;

public sealed class Course : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int Credits { get; set; }
}
