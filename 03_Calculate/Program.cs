using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Моя сисетма по умолчанию EN
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

            try
            {
                Calculate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"В калькуляторе произошла ошибка: {e.Message}");
            }
        }

        public static void Calculate()
        {

            int number01 = 0;
            int number02 = 0;
            string[] Expression = null;

            while (true)
            {
                try
                {
                    Console.Write("Введите выражение (пример: 1 + 1): ");
                    var expression = Console.ReadLine();

                    if (expression == "стоп" || expression == "stop") break;

                    Expression = expression.Split(' ');

                    if (Expression.Length == 2)
                    {
                        try
                        {
                            number01 = int.Parse(Expression[0]);
                            number02 = int.Parse(Expression[1]);
                        }
                        catch
                        {
                            throw new InvalidExpressionException();
                        }

                        throw new EmptyOperatorException();
                    }
                    else if (Expression.Length != 3)
                        throw new InvalidExpressionException();

                    IntParse(Expression[0], ref number01);
                    IntParse(Expression[2], ref number02);

                    switch (Expression[1])
                    {
                        case "+":
                            Sum(number01, number02);
                            break;
                        case "-":
                            Sub(number01, number02);
                            break;
                        case "*":
                            Mul(number01, number02);
                            break;
                        case "/":
                            Div(number01, number02);
                            break;
                        default:
                            // Возможность передавать значение пописана на будущее
                            throw new InvalidOperationsException(Expression[1]);
                    }
                }
                catch (InvalidExpressionException e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write
                    (
                        "Выражение некорректное, попробуйте написать в формате\n" +
                        "a + b\n" +
                        "a - b\n" +
                        "a * b\n" +
                        "a / b\n"
                    );
                    Console.ResetColor();
                }
                catch (EmptyOperatorException e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Укажите в выражении оператор: +, -, *, /");
                    Console.ResetColor();
                }
                catch (InvalidOperandException e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Операнд {e.Operand} не является числом");
                    Console.ResetColor();
                }
                catch (OperandOverflowException e)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write
                    (
                        e.Operand == Expression[0] ?
                        "Первое число " :
                        "Второе число "
                    );
                    Console.WriteLine
                    (
                        $"({e.Operand}), вышло за границы int\n" +
                        "Диапозон от -2.147.483.648 до 2.147.483.647"
                    );
                    Console.ResetColor();
                }
                catch (InvalidOperationsException e)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
                catch (DivideByZeroException e)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Деление на ноль");
                    Console.ResetColor();
                }
                catch (OverflowException e)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine
                    (
                        "Ответ выражения вышел за границы int\n" +
                        "Диапозон от -2 147 483 648 до 2 147 483 647"
                    );
                    Console.ResetColor();
                }
                catch (AnswerException e)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    // Выводит свой текст
                    Console.WriteLine("вы получили ответ 13!");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Проверка парсинга операнда с исключениями
        /// </summary>
        /// <param name="str">Сырая переменная</param>
        /// <param name="value">Ссылочная переменная, для парсинга</param>
        /// <exception cref="OperandOverflowException">Ошибка при выходе значения за пределы INT</exception>
        /// <exception cref="InvalidOperandException">Ошибка при парсинге</exception>
        public static void IntParse(string str, ref int value)
        {
            try
            {
                value = int.Parse(str);
            }
            catch (OverflowException e)
            {
                throw new OperandOverflowException(str);
            }
            catch (Exception e)
            {
                try
                {
                    var dValue = double.Parse(str);
                }
                catch
                {
                    throw new InvalidOperandException(str);
                }
                throw new Exception();
            }
        }

        /// <summary>
        /// Функция сложения двух целых чисел
        /// </summary>
        /// <param name="a">Первое int число</param>
        /// <param name="b">Второе int число</param>
        static void Sum(int a, int b)
        {
            checked
            {
                Console.WriteLine($"Ответ: {a + b}");
            }

            if (a + b == 13)
                throw new AnswerException();
        }

        /// <summary>
        /// Функция вычитания двух целых чисел
        /// </summary>
        /// <param name="a">Первое int число</param>
        /// <param name="b">Второе int число</param>
        static void Sub(int a, int b)
        {
            checked
            {
                Console.WriteLine($"Ответ: {a - b}");
            }

            if (a - b == 13)
                throw new AnswerException();
        }

        /// <summary>
        /// Функция умножения двух целых чисел
        /// </summary>
        /// <param name="a">Первое int число</param>
        /// <param name="b">Второе int число</param>
        static void Mul(int a, int b)
        {
            checked
            {
                Console.WriteLine($"Ответ: {a * b}");
            }

            if (a * b == 13)
                throw new AnswerException();
        }

        /// <summary>
        /// Функция деления двух целых чисел
        /// </summary>
        /// <param name="a">Первое int число</param>
        /// <param name="b">Второе int число</param>
        static void Div(int a, int b)
        {
            checked
            {
                Console.WriteLine($"Ответ: {a / b}");
            }

            if (a / b == 13)
                throw new AnswerException();
        }

        /// <summary>
        /// Ошибка при некорректном выражении
        /// </summary>
        public class InvalidExpressionException : Exception
        {

        }

        /// <summary>
        /// Ошибка при отсутствии оператора
        /// </summary>
        public class EmptyOperatorException : Exception
        {

        }

        /// <summary>
        /// Ошибка при неверно заданном значении для парсинга
        /// Требует передать значение, которое не получилось запарсить
        /// </summary>
        public class InvalidOperandException : Exception
        {
            public string Operand { get; }
            public InvalidOperandException(string operand)
            {
                Operand = operand;
            }
        }

        /// <summary>
        /// Ошибка при введенном операторе, который не входит/соответствует программе
        /// Имеет текст по умолчанию и требует передать оператор
        /// </summary>
        public class InvalidOperationsException : Exception
        {
            public InvalidOperationsException(string message)
                : base(message)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Я пока не умею работать с оператором ");
                Console.ResetColor();
                
            }
        }
        
        /// <summary>
        /// Ошибка при выходе операнда за пределы INT
        /// Требует передать операнд
        /// </summary>
        public class OperandOverflowException : Exception
        {
            public string Operand { get; }
            public OperandOverflowException(string operand)
            {
                Operand = operand;
            }
        }

        /// <summary>
        /// Ошибка при получении ответа 13
        /// </summary>
        public class AnswerException : Exception
        {

        }   
    }
}