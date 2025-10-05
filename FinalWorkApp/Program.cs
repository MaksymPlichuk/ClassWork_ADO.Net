using FinalWorkDataLibrary;
using FinalWorkDataLibrary.Entities;
using System.Globalization;

namespace FinalWorkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Crud crud = new Crud();

            
            Console.WriteLine("--Welcome Chose a Key--");
            while (true) {
                Console.Write("\n[ A ] - CRUD\n[ B ] - Show Different statistics\n[ Z ] - Exit\n"); var mainkey = Console.ReadKey(true);
                if (mainkey.Key == ConsoleKey.A)
                {
                    while (true)
                    {
                        Console.Write("\n[ A ] - Add Data\n[ B ] - Update Data\n[ C ] - Delete Data\n"); var crudkey = Console.ReadKey(true);
                        if (crudkey.Key == ConsoleKey.A)
                        {
                            crud.Add();
                            break;
                        }
                        else if (crudkey.Key == ConsoleKey.B)
                        {
                            crud.Update();
                            break;
                        }
                        else if (crudkey.Key == ConsoleKey.C)
                        {
                            crud.Delete();
                            break;
                        }
                        else { Console.WriteLine("Wrong Key!\n"); }
                    }
                }
                else if (mainkey.Key == ConsoleKey.B)
                {
                    while (true)
                    {


                        Console.Write("\n[ A ] - Country medals\n[ B ] - Different Medalists\n[ C ] - Top country by Gold medals\n[ D ] - Top country by medals\n[ E ] - Top athlete in different sport\n[ F ] - Top country host\n[ G ] - Country performance stat\n"); var statkey = Console.ReadKey(true);
                        if (statkey.Key == ConsoleKey.A)
                        {
                            crud.ShowContryResultInOlympiad();
                            break;
                        }
                        else if (statkey.Key == ConsoleKey.B)
                        {
                            crud.ShowMedalistsFromOlympiad();
                            break;
                        }
                        else if (statkey.Key == ConsoleKey.C)
                        {
                            crud.ShowTopContryGoldMedals();
                            break;
                        }
                        else if (statkey.Key == ConsoleKey.D)
                        {
                            crud.ShowTopContryMedals();
                            break;
                        }
                        else if (statkey.Key == ConsoleKey.E)
                        {
                            crud.ShowTopMedalists();
                            break;
                        }
                        else if (statkey.Key == ConsoleKey.F)
                        {
                            crud.ShowTopCountryHost();
                            break;
                        }
                        else if (statkey.Key == ConsoleKey.G)
                        {
                            crud.CountryPerfStatictics();
                            break;
                        }
                        else { Console.WriteLine("Wrong Key!\n"); }
                    }
                }
                else if (mainkey.Key == ConsoleKey.Z) {
                    Console.WriteLine("GoodBye!");
                    crud.AsciiArt();
                    return;
                }
                else { Console.WriteLine("Wrong Key!\n"); }
            }
        }
    }
}
