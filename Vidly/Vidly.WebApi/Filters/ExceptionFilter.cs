using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vidly.Exceptions;

namespace Vidly.WebApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        try
        {
            throw context.Exception;
        }
        catch (ResourceNotFoundException e)
        {
            context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 404 };
        }
        catch (InvalidResourceException e)
        {
            context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 400 };
        }
        catch (InvalidOperationException e)
        {
            // 409 - Conflict
            context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 409 };
        }
        catch (InvalidCredentialException e)
        {
            context.Result = new ObjectResult(new { Message = e.Message }) { StatusCode = 401 };
        }
        catch (Exception e)
        {
            // En un proyecto real, se agrega logging mas sofisticado
            Console.WriteLine($"Message: {e.Message} - StackTrace: {e.StackTrace}");

            context.Result = new ObjectResult(new
                    { Message = "We encountered some issues, try again later" })
                    { StatusCode = 500 };
        }
    }
}