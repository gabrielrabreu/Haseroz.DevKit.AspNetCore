using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haseroz.DevKit.AspNetCore;

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder ProducesOk<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status200OK, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesCreated<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status201Created, typeof(TResponse), contentType, additionalContentTypes);
    }
    public static RouteHandlerBuilder ProducesNoContent(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status204NoContent, null, contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesBadRequest<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status400BadRequest, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesBadRequest(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.ProducesBadRequest<ProblemDetails>(contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesUnauthorized<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status401Unauthorized, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesUnauthorized(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.ProducesUnauthorized<ProblemDetails>(contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesForbidden<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status403Forbidden, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesForbidden(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.ProducesForbidden<ProblemDetails>(contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesNotFound<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status404NotFound, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesNotFound(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.ProducesNotFound<ProblemDetails>(contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesConflict<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status409Conflict, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesConflict(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.ProducesConflict<ProblemDetails>(contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesInternalServerError<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status500InternalServerError, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesInternalServerError(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.ProducesInternalServerError<ProblemDetails>(contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesServiceUnavailable<TResponse>(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.Produces(StatusCodes.Status503ServiceUnavailable, typeof(TResponse), contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesServiceUnavailable(
        this RouteHandlerBuilder builder,
        string? contentType = null,
        params string[] additionalContentTypes)
    {
        return builder.ProducesServiceUnavailable<ProblemDetails>(contentType, additionalContentTypes);
    }

    public static RouteHandlerBuilder ProducesDefaultErrorResponses(
        this RouteHandlerBuilder builder)
    {
        builder.ProducesBadRequest();
        builder.ProducesUnauthorized();
        builder.ProducesForbidden();
        builder.ProducesNotFound();
        builder.ProducesConflict();
        builder.ProducesInternalServerError();
        builder.ProducesServiceUnavailable();
        return builder;
    }
}
