namespace Application.Features.Courses.GetCourseById;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record GetCourseByIdQuery(Guid Id) : IQuery<Result<GetCourseByIdResponse>>;

public sealed record GetCourseByIdResponse(
    Guid Id,
    string Title,
    string Code,
    int Credits
);
