using System.Diagnostics;

namespace OtusHomeWork_07_Loops.Recursions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 10, 20 };
            var StopWatch = new Stopwatch();

            Result(numbers, Fibanachi_Recursion, Fibanachi_Сycle);
        }

        /// <summary>
        /// Метод облегченного вывода в консоль
        /// </summary>
        /// <param name="numbers">Массив с числами</param>
        /// <param name="Recursion">Метод рекурсии</param>
        /// <param name="Сycle">Метод цикла</param>
        public static void Result(int[] numbers, Func<int, int> Recursion, Func<int, int> Сycle)
        {
            var StopWatch = new Stopwatch();

            foreach (var num in numbers)
            {
                StopWatch.Start();
                Console.WriteLine($"Рекурсия: Фибаначи число {num} = {Recursion(num)}");
                StopWatch.Stop();

                Console.WriteLine($"Время: {StopWatch.Elapsed}\n");
                StopWatch.Reset();
            }

            foreach (var num in numbers)
            {
                StopWatch.Start();
                Console.WriteLine($"Цикл: Фибаначи число {num} = {Сycle(num)}");
                StopWatch.Stop();

                Console.WriteLine($"Время: {StopWatch.Elapsed}\n");
                StopWatch.Reset();
            }
        }

        /// <summary>
        /// Рекурсивный метод, возвращает число Фибаначи
        /// </summary>
        /// <param name="a">Порядковый номер Фибаначи</param>
        /// <returns>Число Фибаначи</returns>
        public static int Fibanachi_Recursion(int a)
        {
            if (a > 1)
            {
                return Fibanachi_Recursion(a - 1) + Fibanachi_Recursion(a - 2);
            }
            else
            {
                return a;
            }
        }

        /// <summary>
        /// Циклический метод, возвращает число Фибаначи
        /// </summary>
        /// <param name="a">Порядковый номер Фибаначи</param>
        /// <returns>Число Фибаначи</returns>
        public static int Fibanachi_Сycle(int a)
        {
            if (a <= 1)
                return 0;
            else if (a == 2)
                return 1;

            int n1 = 0;
            int n2 = 1;
            int result = 0;
            for (int i = 0; i < a - 1; i++)
            {
                result = n1 + n2;
                n1 = n2;
                n2 = result;
            }

            return result;
        }
    }
}