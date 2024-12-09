namespace eCommerce.Application.Common.Bases;
public class BaseResponseError : BaseResponseGeneric<string>
{
    public BaseResponseError(IEnumerable<BaseError> errors)
    {
        Errors = errors;
        Data = null;
    }

    public BaseResponseError(string errorCode, string errorMessage)
    {
        var baseError = new BaseError(errorCode, errorMessage);

        Errors = [baseError];
        Data = null;
    }
}
