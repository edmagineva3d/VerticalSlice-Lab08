namespace Application.Features.Admissions.GetAdmissionById;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record GetAdmissionByIdQuery(Guid Id) : IQuery<Result<GetAdmissionByIdResponse>>;

public sealed record GetAdmissionByIdResponse(
    Guid Id,
    Guid StudentId,
    string StudentName,
    string AcademicYear,
    DateTime AdmissionDate,
    List<CourseResponse> Courses
);

public sealed record CourseResponse(
    Guid Id,
    string Title,
    string Code,
    int Credits
);
