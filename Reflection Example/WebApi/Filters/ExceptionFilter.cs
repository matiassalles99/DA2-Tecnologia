using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    try
    {
      throw context.Exception;
    }
    // Catchear todas las excepciones que conozco
    catch (ResourceNotFoundException e)
    {
      context.Result = new ContentResult()
      {
        StatusCode = 404,
        Content = e.Message
      };
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      // Todo: Loggear
      context.Result = new ContentResult()
      {
        StatusCode = 500,
        Content = "Error interno del servidor, intentelo mas tarde.."
      };
    }
  }
}