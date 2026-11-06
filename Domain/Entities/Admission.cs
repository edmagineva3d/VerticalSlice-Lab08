namespace Domain.Entities;

using Domain.Common;

public sealed class Admission : BaseEntity
{
    public Guid StudentId { get; set; }
    public Student Student { get; set; } = default!;
    public DateTime AdmissionDate { get; set; }
    public string AcademicYear { get; set; } = default!;
    public ICollection<AdmissionCourse> AdmissionCourses { get; set; } = new List<AdmissionCourse>();
}
