namespace Application.Features.Students.CreateStudent;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record CreateStudentCommand(
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth
) : ICommand<Result<CreateStudentResponse>>;

public sealed record CreateStudentResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth
);
