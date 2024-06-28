using FluentResults;

namespace Example.MultiTenantData.Contracts.Results;

public class RequestValidationError(string message) : Error(message);