namespace Application.Features.Students.GetStudentById;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

public sealed class GetStudentByIdQueryHandler(IAppDbContext dbContext)
    : IQueryHandler<GetStudentByIdQuery, Result<GetStudentByIdResponse>>
{
    public async Task<Result<GetStudentByIdResponse>> HandleAsync(
        GetStudentByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var student = await dbContext.Students
            .FirstOrDefaultAsync(s => s.Id == query.Id, cancellationToken);

        if (student is null)
        {
            return Result<GetStudentByIdResponse>.Failure(
                Error.NotFound("Student.NotFound", "Student not found."));
        }

        var response = new GetStudentByIdResponse(
            student.Id,
            student.FirstName,
            student.LastName,
            student.Email,
            student.DateOfBirth
        );

        return Result<GetStudentByIdResponse>.Success(response);
    }
}
