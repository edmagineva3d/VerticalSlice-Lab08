namespace Application.Features.Courses.GetAllCourses;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record GetAllCoursesQuery() : IQuery<Result<GetAllCoursesResponse>>;

public sealed record GetAllCoursesResponse(
    List<CourseResponse> Courses
);

public sealed record CourseResponse(
    Guid Id,
    string Title,
    string Code,
    int Credits
);
