using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlockBuster.Models;
using CsvHelper;

namespace BlockBuster.ConsoleApp
{
    public class ConsoleUtils
    {
        public static void ListMovies(IEnumerable<Movie> movies)
        {
            Console.WriteLine("List of Movies:");

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"Movie Title: {movie.Title},  \nGenre: {movie.Genre?.GenreDescr ?? "N/A"},  \nRelease Year: {movie.ReleaseYear}\n\n");
            }
        }


        public static void WriteMoviesToCsv(IEnumerable<Movie> movies)
        {
            using(var streamWriter = new StreamWriter("..\\Movies.csv"))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {

                    csvWriter.WriteRecords(movies);
                }
            }
        }


        public static void ListObjects<TOutputObj>(IEnumerable<TOutputObj> objectsToShow)
            where TOutputObj : class
        {
            PropertyInfo[] props = typeof(TOutputObj).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            StringBuilder objectStringBuilder = new StringBuilder();

            foreach (TOutputObj obj in objectsToShow)
            {
                foreach (PropertyInfo property in props)
                {
                    objectStringBuilder.Append($"{property.Name}: {property.GetValue(obj)}, ");
                }

                Console.WriteLine(objectStringBuilder.ToString().Trim(',', ' '));
            }
        }
    }
}
