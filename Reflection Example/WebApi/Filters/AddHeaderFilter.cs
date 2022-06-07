using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class AddHeaderFilter : ResultFilterAttribute, IOrderedFilter
{
  private string _name;
  private string _value;

  public AddHeaderFilter(string name, string value)
  {
    _name = name;
    _value = value;
  }

  public override void OnResultExecuting(ResultExecutingContext context)
  {
    context.HttpContext.Response.Headers.Add(_name, _value);
  }
}