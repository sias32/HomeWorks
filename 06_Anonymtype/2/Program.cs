using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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

            var result1 = planets.GetPlanet("Earth");
            Console.WriteLine(result1);

            var result2 = planets.GetPlanet("Limonum");
            Console.WriteLine(result2);

            var result3 = planets.GetPlanet("Mars");
            Console.WriteLine(result3);

            var result4 = planets.GetPlanet("Earth");
            Console.WriteLine(result4);
        }
    }

    public class Planet
    {
        public string Name { get; }
        public int Index { get; }
        public int EquatorLenght { get; }
        public Planet Previous { get; }

        public Planet (string name, int index, int equatorLenght, Planet previous)
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

        // Счетчик запросов
        private int request = 0;
        public (int Index,int Equator,string Message) GetPlanet(string planet)
        {
            request++;
            if (request == 3)
            {
                request = 0;
                return (0, 0, "Вы спрашиваете слишком часто");
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