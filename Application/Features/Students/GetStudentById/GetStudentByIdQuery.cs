namespace Application.Features.Students.GetStudentById;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record GetStudentByIdQuery(Guid Id) : IQuery<Result<GetStudentByIdResponse>>;

public sealed record GetStudentByIdResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime DateOfBirth
);
