using eCommerce.Application.Common.Bases;

namespace eCommerce.Application.Common.Exceptions;
public class NotAuthorizedException : BaseException
{
    public NotAuthorizedException(string errorMessage)
    {
        var baseError = new BaseError(errorCode: "NotAuthorized", errorMessage: errorMessage);

        Errors = [baseError];
    }

}
