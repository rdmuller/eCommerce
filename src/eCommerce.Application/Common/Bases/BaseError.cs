namespace eCommerce.Application.Common.Bases;
public class BaseError
{
    public string? ErrorCode { get; set; }

    public string? ErrorMessage { get; set; }

    public BaseError()
    {
        
    }

    public BaseError(string? errorCode, string? errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }
}
