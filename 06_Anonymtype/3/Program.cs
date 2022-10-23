using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork_06
{
    public static class HomeWork_06
    {
        public static void Main()
        {
            Planet planet01 = new Planet("Venus", 2, 38025, null);
            Planet planet02 = new Planet("Earth", 3, 40075, planet01);
            Planet planet03 = new Planet("Mars", 3, 21344, planet02);

            Planets planets = new Planets(planet01, planet02, planet03);

            // Счетчик делегата запросов
            var Counter = 0;
            
            // Делегат запросов, на каждый третий запрос, выдает предупреждение
            Func<string, string> Validator = (planet) =>
            {
                Counter++;

                if (Counter == 3)
                {
                    Counter = 0;
                    return "Вы спрашиваете слишком часто";
                }

                return null;
            };

            // Делегат проверки планеты, выдает предупреждение об определенной планете
            Func<string, string> notLimonum = (planet) =>
            {
                if (planet == "Limonum")
                {
                    return "Это запретная планета";
                }

                return null;
            };

            var result1 = planets.GetPlanet("Earth", Validator);
            Console.WriteLine(result1);

            var result2 = planets.GetPlanet("Venus", Validator);
            Console.WriteLine(result2);

            var result3 = planets.GetPlanet("Mars", Validator); 
            Console.WriteLine(result3);

            var result4 = planets.GetPlanet("Limonum", Validator);
            Console.WriteLine(result4);

            Console.WriteLine("Проверка второго выражения");

            var result5 = planets.GetPlanet("Limonum", notLimonum);
            Console.WriteLine(result5);
        }
    }

    public class Planet
    {
        public string Name { get; }
        public int Index { get; }
        public int EquatorLenght { get; }
        public Planet Previous { get; }

        public Planet(string name, int index, int equatorLenght, Planet previous)
        {
            Name = name;
            Index = index;
            EquatorLenght = equatorLenght;
            Previous = previous;
        }
    }

    public class Planets
    {
        private List<Planet> planetList = new List<Planet>();

        public Planets(params Planet[] planet)
        {
            foreach (var item in planet)
            {
                planetList.Add(item);
            }
        }

        public (int Index, int Equator, string Message) GetPlanet(string planet, Func<string, string> PlanetValidator)
        {
            var result = PlanetValidator(planet);
            if (result != null)
            {
                return (0, 0, result);
            }

            foreach (var item in planetList)
            {
                if (item.Name == planet)
                {
                    return (item.Index, item.EquatorLenght, item.Name);
                }
            }

            return (0, 0, "Не удалось найти планету");
        }
    }
}