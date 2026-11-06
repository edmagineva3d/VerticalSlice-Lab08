namespace Application.Features.Courses.GetCourseById;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

public sealed class GetCourseByIdQueryHandler(IAppDbContext dbContext)
    : IQueryHandler<GetCourseByIdQuery, Result<GetCourseByIdResponse>>
{
    public async Task<Result<GetCourseByIdResponse>> HandleAsync(
        GetCourseByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var course = await dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == query.Id, cancellationToken);

        if (course is null)
        {
            return Result<GetCourseByIdResponse>.Failure(
                Error.NotFound("Course.NotFound", "Course not found."));
        }

        var response = new GetCourseByIdResponse(
            course.Id,
            course.Title,
            course.Code,
            course.Credits
        );

        return Result<GetCourseByIdResponse>.Success(response);
    }
}
