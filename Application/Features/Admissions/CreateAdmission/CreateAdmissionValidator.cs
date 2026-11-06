namespace Application.Features.Admissions.CreateAdmission;

using FluentValidation;

public sealed class CreateAdmissionValidator : AbstractValidator<CreateAdmissionCommand>
{
    public CreateAdmissionValidator()
    {
        RuleFor(x => x.StudentId).NotEmpty();
        RuleFor(x => x.AcademicYear).NotEmpty().MaximumLength(20);
        RuleFor(x => x.CourseIds).NotEmpty();
    }
}
