using Ardalis.Result;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Haseroz.DevKit.AspNetCore.UnitTests;

public class MinimalApiResultExtensionsTests
{
    private readonly Faker _faker = new();

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsSuccess_ShouldReturnOk()
    {
        // Arrange
        var result = Result<string>.Success(_faker.Random.Word());
        
        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        actual.Should().BeOfType<Ok<string>>()
           .Which.Value.Should().Be(result.Value);
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsCreated_ShouldReturnCreated()
    {
        // Arrange
        var result = Result<string>.Created(_faker.Random.Word(), _faker.Internet.Url());

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var created = actual.Should().BeOfType<Created<string>>().Which;
        created.Value.Should().Be(result.Value);
        created.Location.Should().Be(result.Location);
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsNoContent_ShouldReturnNoContent()
    {
        // Arrange
        var result = Result.NoContent();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        actual.Should().BeOfType<NoContent>();
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsInvalid_ShouldReturnBadRequest()
    {
        // Arrange
        var result = Result.Invalid();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var problemDetails = actual.Should().BeOfType<BadRequest<ProblemDetails>>().Which.Value;
        problemDetails.Should().NotBeNull();
        problemDetails!.Title.Should().Be("Invalid request.");
        problemDetails.Detail.Should().Be("No specific details provided.");
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsUnauthorized_ShouldReturnProblem()
    {
        // Arrange
        var result = Result.Unauthorized();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var problemDetails = actual.Should().BeOfType<ProblemHttpResult>().Which.ProblemDetails;
        problemDetails.Title.Should().Be("Unauthorized.");
        problemDetails.Detail.Should().Be("No specific details provided.");
        problemDetails.Status.Should().Be(StatusCodes.Status401Unauthorized);
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsForbidden_ShouldReturnProblem()
    {
        // Arrange
        var result = Result.Forbidden();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var problemDetails = actual.Should().BeOfType<ProblemHttpResult>().Which.ProblemDetails;
        problemDetails.Title.Should().Be("Forbidden.");
        problemDetails.Detail.Should().Be("No specific details provided.");
        problemDetails.Status.Should().Be(StatusCodes.Status403Forbidden);
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsNotFound_ShouldReturnNotFound()
    {
        // Arrange
        var result = Result.NotFound();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var problemDetails = actual.Should().BeOfType<NotFound<ProblemDetails>>().Which.Value;
        problemDetails.Should().NotBeNull();
        problemDetails!.Title.Should().Be("Resource not found.");
        problemDetails.Detail.Should().Be("No specific details provided.");
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsConflict_ShouldReturnConflict()
    {
        // Arrange
        var result = Result.Conflict();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var problemDetails = actual.Should().BeOfType<Conflict<ProblemDetails>>().Which.Value;
        problemDetails.Should().NotBeNull();
        problemDetails!.Title.Should().Be("There was a conflict.");
        problemDetails.Detail.Should().Be("No specific details provided.");
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsCriticalError_ShouldReturnProblem()
    {
        // Arrange
        var result = Result.CriticalError();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var problemDetails = actual.Should().BeOfType<ProblemHttpResult>().Which.ProblemDetails;
        problemDetails.Title.Should().Be("Something went wrong.");
        problemDetails.Detail.Should().Be("No specific details provided.");
        problemDetails.Status.Should().Be(StatusCodes.Status500InternalServerError);
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsUnavailable_ShouldReturnProblem()
    {
        // Arrange
        var result = Result.Unavailable();

        // Act
        var actual = result.ToMinimalApiResult();

        // Assert
        var problemDetails = actual.Should().BeOfType<ProblemHttpResult>().Which.ProblemDetails;
        problemDetails.Title.Should().Be("Service unavailable.");
        problemDetails.Detail.Should().Be("No specific details provided.");
        problemDetails.Status.Should().Be(StatusCodes.Status503ServiceUnavailable);
    }

    [Fact]
    public void ToMinimalApiResult_WhenStatusIsNotRecognized_ShouldThrowNotSupportedException()
    {
        // Arrange
        var result = Result.Error();

        // Act & Assert
        result.Invoking(r => r.ToMinimalApiResult()).Should().Throw<NotSupportedException>()
            .WithMessage($"Result {result.Status} conversion is not supported.");
    }
}
