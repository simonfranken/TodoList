using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TodoListApi.Error;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var jsonSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var result = JsonConvert.SerializeObject(
            new TodoListException(exception.Message, code).ToJson(),
            Formatting.Indented,
            jsonSettings
        );
        if (exception is TodoListException todoListException)
        {
            result = JsonConvert.SerializeObject(
                todoListException.ToJson(),
                Formatting.Indented,
                jsonSettings
            );
            code = todoListException.StatusCode;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }



}