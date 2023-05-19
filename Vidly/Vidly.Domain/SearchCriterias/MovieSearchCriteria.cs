using System.Linq.Expressions;
using Vidly.Domain.Entities;

namespace Vidly.Domain.SearchCriterias;

public class MovieSearchCriteria
{
    public string? Title { get; set; }
    public string? Description { get; set; }

    public Expression<Func<Movie, bool>> Criteria()
    {
        return m => String.IsNullOrEmpty(Title) && String.IsNullOrEmpty(Description) || m.Title == Title && m.Description == Description;
    }
}