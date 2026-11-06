namespace Application.Features.Admissions.CreateAdmission;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record CreateAdmissionCommand(
    Guid StudentId,
    string AcademicYear,
    List<Guid> CourseIds
) : ICommand<Result<CreateAdmissionResponse>>;

public sealed record CreateAdmissionResponse(
    Guid Id,
    Guid StudentId,
    string AcademicYear,
    DateTime AdmissionDate,
    List<CourseResponse> Courses
);

public sealed record CourseResponse(
    Guid Id,
    string Title,
    string Code
);
