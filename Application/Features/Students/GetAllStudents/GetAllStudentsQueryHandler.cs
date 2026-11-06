namespace Application.Features.Students.GetAllStudents;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

public sealed class GetAllStudentsQueryHandler(IAppDbContext dbContext)
    : IQueryHandler<GetAllStudentsQuery, Result<GetAllStudentsResponse>>
{
    public async Task<Result<GetAllStudentsResponse>> HandleAsync(
        GetAllStudentsQuery query,
        CancellationToken cancellationToken = default)
    {
        var students = await dbContext.Students
            .Select(s => new StudentResponse(
                s.Id,
                s.FirstName,
                s.LastName,
                s.Email,
                s.DateOfBirth
            ))
            .ToListAsync(cancellationToken);

        var response = new GetAllStudentsResponse(students);
        return Result<GetAllStudentsResponse>.Success(response);
    }
}
