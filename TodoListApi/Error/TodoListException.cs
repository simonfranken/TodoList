using System.Net;

namespace TodoListApi.Error;

public class TodoListException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public TodoListException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public object ToJson()
    {
        return new { Message, StatusCode };
    }
}