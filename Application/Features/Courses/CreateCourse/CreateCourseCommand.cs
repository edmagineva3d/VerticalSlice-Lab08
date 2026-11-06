namespace Application.Features.Courses.CreateCourse;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record CreateCourseCommand(
    string Title,
    string Code,
    int Credits
) : ICommand<Result<CreateCourseResponse>>;

public sealed record CreateCourseResponse(
    Guid Id,
    string Title,
    string Code,
    int Credits
);
