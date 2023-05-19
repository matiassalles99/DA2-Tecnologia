using Vidly.Domain.SearchCriterias;

namespace Vidly.Models.In
{
    public class MovieSearchCriteriaModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public MovieSearchCriteria ToEntity()
        {
            return new MovieSearchCriteria()
            {
                Title = this.Title,
                Description = this.Description
            };
        }
    }
}
