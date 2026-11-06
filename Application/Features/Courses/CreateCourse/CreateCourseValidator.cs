namespace Application.Features.Courses.CreateCourse;

using FluentValidation;

public sealed class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Code).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Credits).GreaterThan(0).LessThanOrEqualTo(6);
    }
}
