using FinalWorkDataLibrary.Entities;
using FinalWorkDataLibrary;

namespace FinalWorkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            OlympiadDbContext context = new OlympiadDbContext();
            Crud crud = new Crud();
            crud.ShowContryResultInOlympiad();



        }
    }
}
