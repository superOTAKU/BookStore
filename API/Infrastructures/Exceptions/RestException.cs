using System.Net;

namespace API.Infrastructures.Exceptions;

/// <summary>
/// 这个异常的作用，就是告诉MiddleWare层如何向客户端返回响应
/// </summary>
public class RestException : Exception
{
    public RestException(int errorCode, HttpStatusCode httpStatus, string? message = null, object? detail = null) : base(message)
    {
        ErrorCode = errorCode;
        HttpStatus = httpStatus;
        Detail = detail;
    }

    public int ErrorCode { get; set; }

    public HttpStatusCode HttpStatus { get; set; }

    public object? Detail { get; set; }
}
