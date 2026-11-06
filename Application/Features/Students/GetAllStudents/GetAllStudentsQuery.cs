namespace Application.Features.Students.GetAllStudents;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record GetAllStudentsQuery() : IQuery<Result<GetAllStudentsResponse>>;

public sealed record GetAllStudentsResponse(
    List<StudentResponse> Students
);

public sealed record StudentResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth
);
