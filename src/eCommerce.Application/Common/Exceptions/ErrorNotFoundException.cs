﻿using eCommerce.Application.Common.Bases;

namespace eCommerce.Application.Common.Exceptions;
public class ErrorNotFoundException : BaseException
{
    public IEnumerable<BaseError> Errors { get; }

    public ErrorNotFoundException(string errorMessage)
    {
        var baseError = new BaseError(errorCode: "RecordNotFound", errorMessage: errorMessage);

        Errors = [baseError];
    }
}