using Newtonsoft.Json;

namespace CleanArchitecture.WebAPI.Middleware;

public sealed class ErrorResult : ErrorstatusCode
{
    public string Message { get; set; } = string.Empty;
}

public class ErrorstatusCode
{
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public sealed class ValidationErrorDetails : ErrorstatusCode
{
    public IEnumerable<string>? Errors { get; set; }
}
