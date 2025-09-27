using _08_DataLibrary;
using _08_DataLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace _08_EFLoadingDataApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirportDbContext context = new AirportDbContext();


            var flight = context.Flights.Include(f => f.Airplane).Include(f=>f.City);

            foreach (var f in flight)
            {
                Console.WriteLine($"Arrival city : {f.ArrivalCity}. " +
                    $"Departure city : {f.DepartureCity}\n " +
                    $"Departure time : {f.DepartureTime.ToShortDateString()}\n" +
                    $"Airplane : {f.AirplaneId} . {f.Airplane.Model}\n" +
                    $"City Name : {f.City.Name}\n" +
                    $"Airplane Type : {f.Airplane.AirplaneType}\n" +
                    $"Max count passangers : {f.Airplane.MaxPassangers}\n");
            }
        }
    }
}
