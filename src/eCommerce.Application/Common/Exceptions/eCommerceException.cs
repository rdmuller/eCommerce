using eCommerce.Application.Common.Bases;

namespace eCommerce.Application.Common.Exceptions;

public class eCommerceException : BaseException
{
    public eCommerceException(string errorCode, string errorMessage)
    {
        var baseError = new BaseError(errorCode: errorCode, errorMessage: errorMessage);

        Errors = [baseError];
    }

    public eCommerceException(string errorMessage)
    {
        var baseError = new BaseError(errorCode: "InvalidOperation", errorMessage: errorMessage);

        Errors = [baseError];
    }

    public eCommerceException(IEnumerable<BaseError> errorMessages)
    {
        Errors = errorMessages;
    }
}
