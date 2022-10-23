using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Создать и посчитать по времени коллекции List, ArrayList, LinkedList
 * Для опыта добавил обычный Array и List<obj>
 *
 * На выполнение этой работы ушло около 3 часов
 * 
 */

namespace HomeWork02_1
{
    public class Program
    {
        /// <summary>
        /// Метод заполнения, вычисления переменных по условию для Array
        /// </summary>
        /// <param name="array"></param>
        static void StandartArrayM(int[] array)
        {
            // Таймеры
            var SWRecording = new Stopwatch();
            var SWSerach = new Stopwatch();
            var SWRemainder = new Stopwatch();

            SWRecording.Start();
            // Заполняет переменными
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            SWRecording.Stop();

            SWSerach.Start();
            // Ищет конкретное число
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 496753)
                {
                    Console.WriteLine($"Обычный массив: поиск {496753}, это элемент {i} = {array[i]}");
                }
            }
            SWSerach.Stop();

            SWRemainder.Start();
            // Выводит Элемент, который делится на 777
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 777 == 0)
                {
                    Console.WriteLine($"Обычный массив: этот элемент {i} = {array[i]}, делится на 777");
                }
            }
            SWRemainder.Stop();

            // Для вывода в секундах
            double Recording = (double)SWRecording.ElapsedMilliseconds / 1000;
            double Serach = (double)SWSerach.ElapsedMilliseconds / 1000;
            double Remainder = (double)SWRemainder.ElapsedMilliseconds / 1000;

            Console.WriteLine($"Время на запись {Recording}");
            Console.WriteLine($"Время на поиск {Serach}");
            Console.WriteLine($"Время на поиск без остатка {Remainder}");

            Console.WriteLine("Для продолжения нажмите, любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Метод заполнения, вычисления переменных по условию для List
        /// </summary>
        /// <param name="array"></param>
        static void ListM(List<int> array, int sizeM)
        {
            // Таймеры
            var SWRecording = new Stopwatch();
            var SWSerach = new Stopwatch();
            var SWRemainder = new Stopwatch();

            // Заполняет переменными
            SWRecording.Start();
            for (int i = 0; i < sizeM; i++)
            {
                array.Add(i + 1);
            }
            SWRecording.Stop();

            SWSerach.Start();
            // Ищет конкретное число
            for (int i = 0; i < sizeM; i++)
            {
                if (array[i] == 496753)
                {
                    Console.WriteLine($"Обычный лист: поиск {496753}, это элемент {i} = {array[i]}");
                }
            }
            SWSerach.Stop();

            // Выводит Элемент, который делится на 777
            SWRemainder.Start();
            for (int i = 0; i < sizeM; i++)
            {
                if (array[i] % 777 == 0)
                {
                    Console.WriteLine($"Обычный лист:этот элемент {i} = {array[i]}, делится на 777");
                }
            }
            SWRemainder.Stop();

            // Для вывода в секундах
            double Recording = (double)SWRecording.ElapsedMilliseconds / 1000;
            double Serach = (double)SWSerach.ElapsedMilliseconds / 1000;
            double Remainder = (double)SWRemainder.ElapsedMilliseconds / 1000;

            Console.WriteLine($"Время на запись {Recording}");
            Console.WriteLine($"Время на поиск {Serach}");
            Console.WriteLine($"Время на поиск без остатка {Remainder}");

            Console.WriteLine("Для продолжения нажмите, любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Метод заполнения, вычисления переменных по условию для LinkedList
        /// </summary>
        /// <param name="array"></param>
        static void LinkedListM(LinkedList<int> array, int sizeM)
        {
            // Таймеры
            var SWRecording = new Stopwatch();
            var SWSerach = new Stopwatch();
            var SWRemainder = new Stopwatch();

            // Заполняет переменными
            SWRecording.Start();
            for (int i = 0; i < sizeM; i++)
            {
                array.AddLast(i + 1);
            }
            SWRecording.Stop();

            SWSerach.Start();
            foreach (var item in array)
            {
                if (item == 496753)
                {
                    Console.WriteLine($"Ссылочный лист: поиск {496753}, это {item}");
                }
            }
            SWSerach.Stop();

            // Выводит Элемент, который делится на 777
            SWRemainder.Start();
            foreach (var item in array)
            {
                if (item % 777 == 0)
                {
                    Console.WriteLine($"Ссылочный лист: этот элемент {item}, делиться на 777");
                }
            }
            SWRemainder.Stop();

            // Для вывода в секундах
            double Recording = (double)SWRecording.ElapsedMilliseconds / 1000;
            double Serach = (double)SWSerach.ElapsedMilliseconds / 1000;
            double Remainder = (double)SWRemainder.ElapsedMilliseconds / 1000;

            Console.WriteLine($"Время на запись {Recording}");
            Console.WriteLine($"Время на поиск {Serach}");
            Console.WriteLine($"Время на поиск без остатка {Remainder}");

            Console.WriteLine("Для продолжения нажмите, любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Метод заполнения, вычисления переменных по условию для ArrayList
        /// </summary>
        /// <param name="array"></param>
        static void ArrayListM(ArrayList array, int sizeM)
        {
            // Таймеры
            var SWRecording = new Stopwatch();
            var SWSerach = new Stopwatch();
            var SWRemainder = new Stopwatch();

            // Заполняет переменными
            SWRecording.Start();
            for (int i = 0; i < sizeM; i++)
            {
                array.Add(i + 1);
            }
            SWRecording.Stop();

            // Ищет конкретное число
            SWSerach.Start();
            for (int i = 0; i < sizeM; i++)
            {
                if ((int)array[i] == 496753)
                {
                    Console.WriteLine($"Список массивов: поиск {496753}, это элемент {i} = {array[i]}");
                }
            }
            SWSerach.Stop();

            // Выводит Элемент, который делится на 777
            SWRemainder.Start();
            for (int i = 0; i < sizeM; i++)
            {
                if ((int)array[i] % 777 == 0)
                {
                    Console.WriteLine($"Список массивов: это элемент {i} = {array[i]}, делится на 777,");
                }
            }
            SWRemainder.Stop();

            // Для вывода в секундах
            double Recording = (double)SWRecording.ElapsedMilliseconds / 1000;
            double Serach = (double)SWSerach.ElapsedMilliseconds / 1000;
            double Remainder = (double)SWRemainder.ElapsedMilliseconds / 1000;

            Console.WriteLine($"Время на запись {Recording}");
            Console.WriteLine($"Время на поиск {Serach}");
            Console.WriteLine($"Время на поиск без остатка {Remainder}");

            Console.WriteLine("Для продолжения нажмите, любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Main(string[] args)
        {
            // По умолчанию у моей системы en-EN
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

            // Создаю переменную, указывающую размер
            const int size = 1000000;

            var StandartArray = new int[size];
            var StandartList = new List<int>(size);
            var LinkedList = new LinkedList<int>();
            var ArrayList = new ArrayList(size);

            // Методы, для вывода массивов и коллекций
            StandartArrayM(StandartArray);
            ListM(StandartList, size);
            LinkedListM(LinkedList, size);
            ArrayListM(ArrayList, size);
        }
    }
}
