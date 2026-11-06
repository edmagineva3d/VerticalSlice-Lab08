namespace Application.Features.Courses.GetAllCourses;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

public sealed class GetAllCoursesQueryHandler(IAppDbContext dbContext)
    : IQueryHandler<GetAllCoursesQuery, Result<GetAllCoursesResponse>>
{
    public async Task<Result<GetAllCoursesResponse>> HandleAsync(
        GetAllCoursesQuery query,
        CancellationToken cancellationToken = default)
    {
        var courses = await dbContext.Courses
            .Select(c => new CourseResponse(
                c.Id,
                c.Title,
                c.Code,
                c.Credits
            ))
            .ToListAsync(cancellationToken);

        var response = new GetAllCoursesResponse(courses);
        return Result<GetAllCoursesResponse>.Success(response);
    }
}
