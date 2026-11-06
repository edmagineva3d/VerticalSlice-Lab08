namespace Domain.Entities;

using Domain.Common;

public sealed class AdmissionCourse : BaseEntity
{
    public Guid AdmissionId { get; set; }
    public Guid CourseId { get; set; }
    public Admission Admission { get; set; } = default!;
    public Course Course { get; set; } = default!;
}
