namespace BlockBuster.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.ListMovies(BasicFunctions.GetAllMovies());
            //ConsoleUtils.ListObjects(BasicFunctions.GetAllMovies());
            //ConsoleUtils.WriteMoviesToCsv(BasicFunctions.GetAllMovies());
        }
    }
}
