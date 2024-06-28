using FluentResults;

using Example.MultiTenantData.Contracts.Results;

using Microsoft.AspNetCore.Mvc;

namespace Example.MultiTenantData.Api.Controllers;

public static class ControllerBaseExtensions
{
    public static IActionResult GetResult<T>(this ControllerBase controllerBase, Result<T> result) where T : class
    {
        if (!result.IsSuccess)
            return controllerBase.GetErrorResults(result);

        return controllerBase.GetSuccessResults(result);
    }

    public static IActionResult GetResult(this ControllerBase controllerBase, Result result)
    {
        if (!result.IsSuccess)
            return controllerBase.GetErrorResults(result);

        return controllerBase.GetSuccessResults(result);
    }

    private static IActionResult GetSuccessResults<T>(this ControllerBase controllerBase, Result<T> result) where T : class
    {
        var success = result.Successes.FirstOrDefault();

        if (success is ResourceCreated)
            return controllerBase.Created(string.Empty, result.Value);

        return controllerBase.Ok(result.Value);
    }

    private static IActionResult GetSuccessResults(this ControllerBase controllerBase, Result result)
    {
        var success = result.Successes.FirstOrDefault();

        if (success is ResourceCreated)
            return controllerBase.Created(string.Empty, null);

        return controllerBase.Ok();
    }

    private static IActionResult GetErrorResults(this ControllerBase controllerBase, IResultBase result)
    {
        var error = result.Errors.FirstOrDefault();

        if (error is null)
            return controllerBase.StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");

        return error switch
        {
            NotFoundError notFoundError => controllerBase.NotFound(notFoundError.Message),
            RequestValidationError badRequestError => controllerBase.BadRequest(badRequestError.Message),
            _ => controllerBase.StatusCode(StatusCodes.Status500InternalServerError, error.Message)
        };
    }
}
