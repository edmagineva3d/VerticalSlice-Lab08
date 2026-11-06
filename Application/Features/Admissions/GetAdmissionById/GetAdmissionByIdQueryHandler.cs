namespace Application.Features.Admissions.GetAdmissionById;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

public sealed class GetAdmissionByIdQueryHandler(IAppDbContext dbContext)
    : IQueryHandler<GetAdmissionByIdQuery, Result<GetAdmissionByIdResponse>>
{
    public async Task<Result<GetAdmissionByIdResponse>> HandleAsync(
        GetAdmissionByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var admission = await dbContext.Admissions
            .Include(a => a.AdmissionCourses)
                .ThenInclude(ac => ac.Course)
            .Include(a => a.Student)
            .FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

        if (admission is null)
        {
            return Result<GetAdmissionByIdResponse>.Failure(
                Error.NotFound("Admission.NotFound", "Admission not found."));
        }

        var response = new GetAdmissionByIdResponse(
            admission.Id,
            admission.StudentId,
            $"{admission.Student.FirstName} {admission.Student.LastName}",
            admission.AcademicYear,
            admission.AdmissionDate,
            admission.AdmissionCourses.Select(ac => new CourseResponse(
                ac.Course.Id,
                ac.Course.Title,
                ac.Course.Code,
                ac.Course.Credits
            )).ToList()
        );

        return Result<GetAdmissionByIdResponse>.Success(response);
    }
}
