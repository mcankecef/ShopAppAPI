namespace ShopAppAPI.Application.Exceptions;

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> ValidationErrors { get; set; }

    public ValidationException() : base()
    {
        ValidationErrors = new List<ValidationExceptionModel>();
    }
    public ValidationException(string? message) : base(message)
    {
        ValidationErrors = new List<ValidationExceptionModel>();
    }
    public ValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
        ValidationErrors = new List<ValidationExceptionModel>();
    }
    public ValidationException(IEnumerable<ValidationExceptionModel> validationErrors) : base(GenerateErrorMessage(validationErrors))
    {
        ValidationErrors = validationErrors;
    }

    private static string GenerateErrorMessage(IEnumerable<ValidationExceptionModel> validationErrors)
    {
        IEnumerable<string> validationErrorMessages = validationErrors.Select(e => $"{Environment.NewLine} - {e.Property}: {string.Join(Environment.NewLine, values: e.Errors)}");
        return $"Validation failed: {string.Concat(validationErrorMessages)}";
    }
}
public class ValidationExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}
