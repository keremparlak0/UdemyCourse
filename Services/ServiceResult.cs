using System;
using System.Net;

namespace Services;

public class ServiceResult<T>
{
    public T? Data { get; set; }
    public IList<string>? ErrorMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public bool IsSuccess()
    {

        return this.ErrorMessage is null || this.ErrorMessage.Count == 0;
    }

    public bool isFailure => !IsSuccess();

    public static ServiceResult<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ServiceResult<T>
        {
            Data = data,
            StatusCode = statusCode
        };
    }

    public static ServiceResult<T> Failure(string errorMessages, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult<T>
        {
            ErrorMessage = [errorMessages], // new List<string> { errorMessages }
            StatusCode = statusCode
        };
    }

    public static ServiceResult<T> Failure(IList<string> errorMessages)
    {
        return new ServiceResult<T>
        {
            ErrorMessage = errorMessages,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}



public class ServiceResult
{
    public IList<string>? ErrorMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public bool IsSuccess()
    {

        return this.ErrorMessage is null || this.ErrorMessage.Count == 0;
    }

    public bool isFailure => !IsSuccess();

    public static ServiceResult Success(HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ServiceResult
        {
            StatusCode = statusCode
        };
    }

    public static ServiceResult Failure(string errorMessages, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult
        {
            ErrorMessage = [errorMessages], // new List<string> { errorMessages }
            StatusCode = statusCode
        };
    }

    public static ServiceResult Failure(IList<string> errorMessages)
    {
        return new ServiceResult
        {
            ErrorMessage = errorMessages,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}
