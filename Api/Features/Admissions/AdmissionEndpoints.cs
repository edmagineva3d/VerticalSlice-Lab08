
namespace Api.Features.Admissions;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Data;
using Api.Common.Authorization;
using Api.Common.Extensions;
using Application.Abstractions.Messaging;
using Application.Features.Admissions.CreateAdmission;
using Application.Features.Admissions.GetAdmissionById;
using Domain.Common;

public static class AdmissionEndpoints
{
    public static void MapAdmissionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/admissions")
            .WithTags("Admissions")
            .RequireAuthorization();

        group.MapPost("/", Create)
            .WithName("CreateAdmission")
            .WithSummary("Create a new admission with courses")
            .RequireAuthorization(Policies.CanManageAdmissions);

        group.MapGet("/{id:guid}", GetById)
            .WithName("GetAdmissionById")
            .WithSummary("Get admission by ID with courses");
    }

    private static async Task<IResult> Create(
        CreateAdmissionCommand command,
        ICommandHandler<CreateAdmissionCommand, Result<CreateAdmissionResponse>> handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.HandleAsync(
            command,
            cancellationToken);

        return result.IsSuccess
            ? TypedResults.CreatedAtRoute(
                result.Value,
                "GetAdmissionById",
                new { id = result.Value!.Id })
            : result.ToProblemDetails();
    }

    private static async Task<IResult> GetById(
      Guid id,
      IQueryHandler<GetAdmissionByIdQuery, Result<GetAdmissionByIdResponse>> handler,
      IAuthorizationService authorizationService,
      IAppDbContext dbContext,
      ClaimsPrincipal user,
      CancellationToken cancellationToken)
    {
        var admission = await dbContext.Admissions
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (admission is null)
        {
            return TypedResults.NotFound();
        }

        var authResult = await authorizationService.AuthorizeAsync(
            user, admission, new AdmissionOwnerRequirement());

        if (!authResult.Succeeded)
        {
            return TypedResults.Forbid();
        }

        var result = await handler.HandleAsync(
            new GetAdmissionByIdQuery(id),
            cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : result.ToProblemDetails();
    }
}