using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lesson1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            try
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("DefaultConnection");

                var optionsBuilder = new DbContextOptionsBuilder<ContinentContext>();
                var options = optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies().Options;

                using (ContinentContext db = new ContinentContext(options))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1. відобразити всю інформацію про країни");
                        Console.WriteLine("2. відобразити назви країн");
                        Console.WriteLine("3. відобразити назви столиць");
                        Console.WriteLine("4. відобразити назви всіх європейських країн");
                        Console.WriteLine("5. відобразити назви країн із площею, яка більша за конкретне число");
                        Console.WriteLine("6. відобразити всі країни, у назві яких є літери «а», «е»");
                        Console.WriteLine("7. відобразити всі країни, назва яких починається з літери «а»");
                        Console.WriteLine("8. відобразити назви країн, площа яких перебуває у вказаному діапазоні");
                        Console.WriteLine("9. відобразити назви країн, у яких кількість жителів більша завказане число");
                        Console.WriteLine("0. Вихід");
                        int result = int.Parse(Console.ReadLine()!);
                        switch (result)
                        {
                            case 1:
                                Console.Clear();
                                var qwery = db.Countries;
                                foreach (var country in qwery)
                                {
                                    Console.WriteLine($"Country {country.Name} - Capital city {country.CapitalCity}");
                                    Console.WriteLine($"Area {country.Area} - Population {country.Population}");
                                    Console.WriteLine($"Continent {country.Continent?.Name}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                qwery = db.Countries;
                                foreach (var country in qwery)
                                {
                                    Console.WriteLine($"Country {country.Name}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                qwery = db.Countries;
                                foreach (var country in qwery)
                                {
                                    Console.WriteLine($"Country {country.CapitalCity}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 4:
                                Console.Clear();
                                var qwery4 = db.Countries.Where(x => x.Continent.Name == "Europe").Select(x => x.Name);
                                
                                foreach (var continent in qwery4)
                                {
                                    Console.WriteLine($"Country {continent}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Введіть мінімальну площу країни:");
                                int area = Convert.ToInt32(Console.ReadLine());
                                var qwery5 = db.Countries.Where(i => i.Area > area).Select(i => $"{i.Name} - {i.Area}");
                                foreach (var country in qwery5)
                                {
                                    Console.WriteLine($"Country {country}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 6:
                                Console.Clear();
                                var qwery6 = db.Countries.Where(i => i.Name.Contains("а") && i.Name.Contains("е")).ToList();
                                foreach (var country in qwery6)
                                {
                                    Console.WriteLine($"Country {country.Name}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 7:
                                Console.Clear();
                                var qwery7 = db.Countries.Where(i => i.Name.StartsWith("а"));
                                foreach (var country in qwery7)
                                {
                                    Console.WriteLine($"Country {country.Name}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 8:
                                Console.Clear();
                                Console.WriteLine("Введіть початок діапазону:");
                                int start = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введіть кінець діапазону:\n");
                                int end = Convert.ToInt32(Console.ReadLine());
                                var qwery8 = db.Countries.Where(i => i.Area >= start && i.Area <= end);
                                foreach (var country in qwery8)
                                {
                                    Console.WriteLine($"Country {country.Name}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 9:
                                Console.Clear();
                                Console.WriteLine("Введіть мінімальну к-сть жителів:");
                                int population = Convert.ToInt32(Console.ReadLine());
                                var qwery9 = db.Countries.Where(i => i.Population > population);
                                foreach (var country in qwery9)
                                {
                                    Console.WriteLine($"Country {country.Name}\n");
                                }
                                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися в меню");
                                Console.ReadKey();
                                break;
                            case 0:
                                return;
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}