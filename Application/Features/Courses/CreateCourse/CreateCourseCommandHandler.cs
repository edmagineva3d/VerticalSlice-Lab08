namespace Application.Features.Courses.CreateCourse;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Domain.Entities;

public sealed class CreateCourseCommandHandler(IAppDbContext dbContext)
    : ICommandHandler<CreateCourseCommand, Result<CreateCourseResponse>>
{
    public async Task<Result<CreateCourseResponse>> HandleAsync(
        CreateCourseCommand command,
        CancellationToken cancellationToken = default)
    {
        var course = new Course
        {
            Title = command.Title,
            Code = command.Code,
            Credits = command.Credits
        };

        dbContext.Courses.Add(course);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = new CreateCourseResponse(
            course.Id,
            course.Title,
            course.Code,
            course.Credits
        );

        return Result<CreateCourseResponse>.Success(response);
    }
}
