using Vidly.Domain.Entities;

namespace Vidly.Models.Out
{
    public class MovieDetailModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public MovieDetailModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Title;
            this.Description = movie.Description;
        }

        public override bool Equals(object? obj)
        {
            var model = obj as MovieDetailModel;
            return model.Id == Id;
        }
    }
}
