using MovieClient.Models;

namespace MovieClient.APIservises
{
    public interface IMovieAPiServises
    {
        Task<IEnumerable<Models.Movie>> GetMoviesAsync();

        Task<Models.Movie> GetMovieAsync(string id);

        Task<Models.Movie> CreateMovie(Movie movie);

        Task<Models.Movie> UpdateMovieAsync(Movie movie);

        Task<Models.Movie> DeleteMovieAsync(int id);



    }
}
