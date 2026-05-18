using Microsoft.EntityFrameworkCore;
namespace lesson1;

public class ContinentContext : DbContext
{
    public ContinentContext(DbContextOptions<ContinentContext> options)
        : base(options)
    {
        if (Database.EnsureCreated())
        {
            Continent continent1 = new Continent { Name = "Asia" };
            Continent continent2 = new Continent { Name = "Europe" };
            Continent continent3 = new Continent { Name = "North America" };
            Continent continent4 = new Continent { Name = "South America" };
            Continent continent5 = new Continent { Name = "Africa" };
            Continent continent6 = new Continent { Name = "Antarctica" };
            Continent continent7 = new Continent { Name = "Oceania" };
            
            Continents.AddRange(new[] { continent1, continent2, continent3, continent4, continent5,
                continent6, continent7 });
            
            Country country1 = new Country { Name = "Китай", CapitalCity = "Пекін", Population = 1404000000 , Area =  9596961, Continent = continent1 }; // 1
            Country country2 = new Country { Name = "Японія", CapitalCity = "Токіо", Population = 123800000, Area = 377975, Continent = continent1 }; // 1
            Country country3 = new Country { Name = "Франція", CapitalCity = "Париж", Population = 68500000, Area = 643801, Continent = continent2 }; // 2
            Country country4 = new Country { Name = "Україна", CapitalCity = "Київ", Population = 41000000, Area = 603628, Continent = continent2 }; // 2
            Country country5 = new Country { Name = "Канада", CapitalCity = "Оттава", Population = 41000000, Area = 9984670, Continent = continent3 };  // 3
            Country country6 = new Country { Name = "Мексика", CapitalCity = "Мехіко", Population = 129500000, Area = 1972550, Continent = continent3 }; // 3
            Country country7 = new Country { Name = "Аргентина", CapitalCity = "Буенос-Айрес", Population = 46600000, Area = 2780400, Continent = continent4 }; // 4
            Country country8 = new Country { Name = "Бразилія", CapitalCity = "Бразиліа", Population = 203000000, Area = 8515767, Continent = continent4 }; // 4
            Country country9 = new Country { Name = "Єгипет", CapitalCity = "Каїр", Population = 114000000, Area = 1010408, Continent = continent5 }; // 5
            Country country10 = new Country { Name = "Марокко", CapitalCity = "Рабат", Population = 37500000, Area = 446550, Continent = continent5 }; // 5
            Country country11 = new Country { Name = "Норвегія", CapitalCity = "Осло", Population = 5550000, Area = 385207, Continent = continent6 }; // 6
            Country country12 = new Country { Name = "Велика Британія", CapitalCity = "Лондон", Population = 68000000, Area = 242495, Continent = continent6 }; // 6
            Country country13 = new Country { Name = "Соломонські Острови", CapitalCity = "Хоніара", Population = 740000, Area = 28400, Continent = continent7 }; // 7
            Country country14 = new Country { Name = "Палау", CapitalCity = "Нгерулмуд", Population = 18000, Area = 459, Continent = continent7 }; // 7
            
            Countries.AddRange(new[] { country1, country2, country3, country4, country5, country6,country7,
                country8, country9, country10, country11, country12, country13, country14 });
            
            SaveChanges();
        }
    }
    public DbSet<Continent> Continents { get; set; }
    public DbSet<Country> Countries { get; set; }
}