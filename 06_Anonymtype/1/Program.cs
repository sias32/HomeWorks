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
            var planet01 = new
            {
                Name = "Venus",
                Index = 2,
                EquatorLenght = 38025,
                Previous = (object)null
            };

            var planet02 = new
            {
                Name = "Earth",
                Index = 3,
                EquatorLenght = 40075,
                Previous = (object)planet01
            };

            var planet03 = new
            {
                Name = "Mars",
                Index = 4,
                EquatorLenght = 21344,
                Previous = (object)planet02
            };

            var planet04 = new
            {
                Name = "Venus",
                Index = 2,
                EquatorLenght = 38025,
                Previous = (object)null
            };

            Console.WriteLine
            (
                "\nPlanet01: " +
                "\nИмя: " + planet01.Name +
                "\nИндекс: " + planet01.Index +
                "\nЭкватор: " + planet01.EquatorLenght +
                "\nРавен ли Planet04: " + planet01.Equals(planet04)
            );

            Console.WriteLine
            (
                "\nPlanet02: " +
                "\nИмя: " + planet02.Name +
                "\nИндекс: " + planet02.Index +
                "\nЭкватор: " + planet02.EquatorLenght +
                "\nРавен ли Planet04: " + planet02.Equals(planet04)
            );

            Console.WriteLine
            (
                "\nPlanet03 " +
                "\nИмя: " + planet03.Name +
                "\nИндекс: " + planet03.Index +
                "\nЭкватор: " + planet03.EquatorLenght +
                "\nРавен ли Planet04: " + planet03.Equals(planet04)
            );
        }
    }
}