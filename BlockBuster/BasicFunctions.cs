using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster
{
    public static class BasicFunctions
    {
        public static Movie? GetMovieById(int movieId)
        {
            using(var context = new Se407BlockBusterContext())
            {
                return context.Movies.Find(movieId);
            }
        }


        public static List<Movie> GetAllMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies.ToList();
            }
        }


        public static List<Movie> GetCheckedOutMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return 
                    context
                        .Transactions
                        .Where(t => t.CheckedIn.Equals("N"))
                        .Join
                        (
                            context.Movies,
                            t => t.MovieId,
                            m => m.MovieId,
                            (t, m) => m
                        )
                        .ToList();
            }
        }
        public static List<Movie> GetMoviesByGenreDescription(string genreDescr)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies
                    .Include(m => m.Genre)
                    .Where(m => m.Genre.GenreDescr == genreDescr)
                    .ToList();
            }
        }
        public static List<Movie> GetMoviesByDirectorLastName(string lastName)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies
                    .Include(m => m.Director)
                    .Where(m => m.Director.LastName == lastName)
                    .ToList();
            }
        }
    }
}
