namespace Application.Features.Students.CreateStudent;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Domain.Entities;

public sealed class CreateStudentCommandHandler(IAppDbContext dbContext)
    : ICommandHandler<CreateStudentCommand, Result<CreateStudentResponse>>
{
    public async Task<Result<CreateStudentResponse>> HandleAsync(
        CreateStudentCommand command,
        CancellationToken cancellationToken = default)
    {
        var student = new Student
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            DateOfBirth = command.DateOfBirth
        };

        dbContext.Students.Add(student);
        await dbContext.SaveChangesAsync(cancellationToken);

        var response = new CreateStudentResponse(
            student.Id,
            student.FirstName,
            student.LastName,
            student.Email,
            student.DateOfBirth
        );

        return Result<CreateStudentResponse>.Success(response);
    }
}
