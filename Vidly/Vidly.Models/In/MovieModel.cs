using Vidly.Domain.Entities;

namespace Vidly.Models.In
{
    public class MovieModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Movie ToEntity()
        {
            return new Movie()
            {
                Title = this.Name,
                Description = this.Description
            };
        }
    }
}
