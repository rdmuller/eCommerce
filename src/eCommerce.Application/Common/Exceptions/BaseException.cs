using eCommerce.Application.Common.Bases;

namespace eCommerce.Application.Common.Exceptions;
public class BaseException : Exception
{
    public virtual IEnumerable<BaseError> Errors { get; protected set; } = [];
}
