using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork01_1
{
    public class HomeWork01_1
    {
        public static void Main(string[] args)
        {
            const int TableMaxWidth = 40;

            int TableDimension = 0;
            string Table01Text;

            int TableFullWidth;
            int TableFullHeight;
            int Table01TextWidth = 0;

            while (true)
            {
                Console.Write("Введите размерность таблицы (от 1 до 6): ");

                var String = Console.ReadLine();

                if (String == "")
                {
                    Console.WriteLine("Ошибка: задана пустая размерность");
                }
                else
                {
                    try
                    {
                        TableDimension = int.Parse(String);
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка: введено некоректное значение");
                        continue;
                    }

                    if (TableDimension <= 6 && TableDimension >= 1)
                    {
                        TableDimension--;

                        // Допустимая ширина текста
                        Table01TextWidth = (TableMaxWidth - (TableDimension * 2)) - 2;

                        break;
                    }    
                    else Console.WriteLine("Ошибка: Неверно задана размерность");
                }
            }

            do
            {
                Console.Write($"Введите произвольный текст (Макс. ширина {Table01TextWidth}): ");

                Table01Text = Console.ReadLine();

                if (Table01Text.Length <= Table01TextWidth)
                {
                    // Полная ширина таблиц
                    TableFullWidth = Table01Text.Length + TableDimension * 2 + 2;

                    // Полная высота таблиц
                    TableFullHeight = TableDimension * 2 + 3;

                    break;
                }
                else Console.WriteLine("Ошибка: Превышена макс. ширина");
            } while (true);

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        Table01(TableFullWidth, TableFullHeight, TableDimension, Table01Text);
                        break;
                    case 1:
                        Table02(TableFullWidth, TableFullHeight);
                        break;
                    case 2:
                        Table03(TableFullWidth);
                        break;
                }
            }
        }
        
        /// <summary>
        /// Выводит первую таблицу с текстом внутри
        /// </summary>
        /// <param name="TableWidth">Ширина таблицы</param>
        /// <param name="TableHeight">Высота таблицы</param>
        /// <param name="TableDimension">Размерность</param>
        /// <param name="Text">Внутренний текст</param>
        static void Table01(int TableWidth, int TableHeight, int TableDimension, string Text)
        {
            for (int i = 0; i < TableHeight; i++)
            {
                if (i == 0 || i == TableHeight - 1)
                {
                    // Построение начала и конца и вывод в одну строку
                    StringBuilder SB = new StringBuilder();
                    for (int j = 0; j < TableWidth; j++)
                    {
                        SB.Append('+');
                    }
                    Console.WriteLine(SB.ToString());
                }
                else if (i == TableHeight / 2)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        switch (j)
                        {
                            case 0:
                            case 4:
                                Console.Write("+");
                                break;
                            case 1:
                            case 3:
                                for (int l = 0; l < TableDimension; l++)
                                {
                                    Console.Write(" ");
                                }
                                break;
                            case 2:
                                Console.Write(Text);
                                break;
                        }
                    }
                    Console.WriteLine("");
                }
                else
                {
                    for (int j = 0; j < TableWidth; j++)
                    {
                        if (j == 0 || j == TableWidth - 1)
                        {
                            Console.Write("+");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("");
                }
            }
        }

        /// <summary>
        /// Выводит вторую таблицу с чередованием
        /// </summary>
        /// <param name="TableWidth">Ширина таблицы</param>
        /// <param name="TableHeight">Высота таблицы</param>
        static void Table02(int TableWidth, int TableHeight)
        {
            for (int i = 0; i < TableHeight - 2; i++)
            {
                for (int j = 0; j < TableWidth; j++)
                {
                    if (j == 0 || j == TableWidth - 1)
                    {
                        Console.Write("+");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write(j % 2 == 0 ? ' ' : '+');
                    }
                    else if (i % 2 != 0)
                    {
                        Console.Write(j % 2 == 0 ? '+' : ' ');
                    }
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Выводит третью таблицу с крестом
        /// </summary>
        /// <param name="TableSideLength">Длина сторон таблицы</param>
        static void Table03(int TableSideLength)
        {
            // Кол-во строк до середины креста
            var TableMiddleString = (TableSideLength - 2) / 2;

            for (int i = 0; i < TableSideLength; i++)
            {
                if (i == 0 || i == TableSideLength - 1)
                {
                    // Построение начала и конца и вывод в одну строку
                    StringBuilder SB = new StringBuilder();
                    for (int j = 0; j < TableSideLength; j++)
                    {
                        SB.Append('+');
                    }
                    Console.WriteLine(SB.ToString());
                }
                else
                {
                    for (int j = 0; j < TableSideLength; j++)
                    {
                        if (j == 0 || j == TableSideLength - 1)
                        {
                            Console.Write("+");
                        }
                        else if (j == i || j == (TableSideLength - 1) - i)
                        {
                            Console.Write("+");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("");
                }
            }
        }
    }
}