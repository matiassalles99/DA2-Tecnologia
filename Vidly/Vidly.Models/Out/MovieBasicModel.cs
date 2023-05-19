using Vidly.Domain.Entities;

namespace Vidly.Models.Out
{
    public class MovieBasicModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MovieBasicModel() { }
        
        public MovieBasicModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Title;
        }
    }
}
