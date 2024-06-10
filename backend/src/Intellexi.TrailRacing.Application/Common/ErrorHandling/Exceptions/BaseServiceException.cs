namespace Intellexi.TrailRacing.Application.Common.ErrorHandling.Exceptions;

public abstract class BaseServiceException : Exception
{
    public ServiceErrorCode ErrorCode { get; }

    public BaseServiceException(ServiceErrorCode errorCode, string message)
        : base(message)
    {
        ErrorCode = errorCode;
    }

    public BaseServiceException(ServiceErrorCode errorCode, string message, Exception innerException)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }

    public virtual CustomProblemDetails ToProblemDetails()
    {
        return new CustomProblemDetails
        {
            Status = GetStatusCode(),
            Type = GetType().Name,
            Title = Message,
            Detail = ErrorCode.ToString()
        };
    }

    public abstract int GetStatusCode();
}