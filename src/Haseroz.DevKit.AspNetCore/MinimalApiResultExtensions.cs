using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;

using IArdalisResult = Ardalis.Result.IResult;
using IHttpResult = Microsoft.AspNetCore.Http.IResult;

namespace Haseroz.DevKit.AspNetCore;

public static class MinimalApiResultExtensions
{
    public static IHttpResult ToMinimalApiResult<T>(this Result<T> result) =>
        result.Status switch
        {
            ResultStatus.Ok => Ok(result),
            ResultStatus.Created => Created(result),
            ResultStatus.NoContent => NoContent(),
            ResultStatus.Invalid => BadRequest(result),
            ResultStatus.Unauthorized => Unauthorized(result),
            ResultStatus.Forbidden => Forbidden(result),
            ResultStatus.NotFound => NotFound(result),
            ResultStatus.Conflict => Conflict(result),
            ResultStatus.CriticalError => InternalServerError(result),
            ResultStatus.Unavailable => ServiceUnavailable(result),
            _ => throw new NotSupportedException($"Result {result.Status} conversion is not supported."),
        };

    private static Ok<T> Ok<T>(Result<T> result)
    {
        return TypedResults.Ok(result.Value);
    }

    private static Created<T> Created<T>(Result<T> result)
    {
        return TypedResults.Created(result.Location, result.Value);
    }

    private static NoContent NoContent()
    {
        return TypedResults.NoContent();
    }

    private static BadRequest<ProblemDetails> BadRequest(IArdalisResult result)
    {
        var details = FormatErrorDetails(result.ValidationErrors.Select(s => s.ErrorMessage));

        return TypedResults.BadRequest(new ProblemDetails
        {
            Title = "Invalid request.",
            Detail = details.ToString()
        });
    }

    private static ProblemHttpResult Unauthorized(IArdalisResult result)
    {
        var details = FormatErrorDetails(result.Errors);

        return TypedResults.Problem(new ProblemDetails
        {
            Title = "Unauthorized.",
            Detail = details.ToString(),
            Status = StatusCodes.Status401Unauthorized
        });
    }

    private static ProblemHttpResult Forbidden(IArdalisResult result)
    {
        var details = FormatErrorDetails(result.Errors);

        return TypedResults.Problem(new ProblemDetails
        {
            Title = "Forbidden.",
            Detail = details.ToString(),
            Status = StatusCodes.Status403Forbidden
        });
    }

    private static NotFound<ProblemDetails> NotFound(IArdalisResult result)
    {
        var details = FormatErrorDetails(result.Errors);

        return TypedResults.NotFound(new ProblemDetails
        {
            Title = "Resource not found.",
            Detail = details.ToString()
        });
    }

    private static Conflict<ProblemDetails> Conflict(IArdalisResult result)
    {
        var details = FormatErrorDetails(result.Errors);

        return TypedResults.Conflict(new ProblemDetails
        {
            Title = "There was a conflict.",
            Detail = details.ToString()
        });
    }

    private static ProblemHttpResult InternalServerError(IArdalisResult result)
    {
        var details = FormatErrorDetails(result.Errors);

        return TypedResults.Problem(new ProblemDetails
        {
            Title = "Something went wrong.",
            Detail = details.ToString(),
            Status = StatusCodes.Status500InternalServerError
        });
    }

    private static ProblemHttpResult ServiceUnavailable(IArdalisResult result)
    {
        var details = FormatErrorDetails(result.Errors);

        return TypedResults.Problem(new ProblemDetails
        {
            Title = "Service unavailable.",
            Detail = details.ToString(),
            Status = StatusCodes.Status503ServiceUnavailable
        });
    }

    private static StringBuilder FormatErrorDetails(IEnumerable<string> errors)
    {
        var details = new StringBuilder();

        if (errors.Any())
        {
            details.Append("Next error(s) occurred:");

            foreach (var error in errors)
            {
                details.Append("* ").Append(error).AppendLine();
            }
        }
        else
        {
            details.Append("No specific details provided.");
        }

        return details;
    }
}
