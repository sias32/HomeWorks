using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeWork04
{
    public class HomeWork04
    {
        public static void Main(string[] args)
        {
            var s = new Stack("a", "b", "c");
            Console.WriteLine($"Создали стэк 's': Size = {s.Size}, Top = '{s.Top}'");
            Console.WriteLine();

            var deleted = s.Pop();
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}, Top = '{s.Top}'");
            Console.WriteLine();

            s.Add("d");
            Console.WriteLine($"Добавил элемент 'd': size = {s.Size}, Top = '{s.Top}'");
            Console.WriteLine();

            s.Pop();
            s.Pop();
            s.Pop();
            Console.WriteLine($"Выполнил 3 метода Pop(): size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            // s.Pop();
            // последующий методо Pop() вызовет исключение
            Console.WriteLine();

            var s2 = new Stack("a", "b", "c");
            s2.Merge(new Stack("1", "2", "3"));
            Console.WriteLine("Метод Merge: соединяет stack (a,b,c) с new stack (1,2,3):");
            Console.Write("Stack { ");
            var size = s2.Size;
            var array = new string[size];
            for (int i = size-1; i > -1; i--)
            {
                array[i] = s2.Pop();
            }
            Console.Write(String.Join(' ', array)); 
            Console.Write(" }\n");
            Console.WriteLine();

            var s3 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            // в стеке s теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний
            Console.WriteLine("Метод Contact: соединяет stack (a,b,c) и stack (1,2,3) и stack(А,Б,В):");
            var size1 = s3.Size;
            var array1 = new string[size1];
            Console.Write("Stack { ");
            for (int i = size1-1; i > -1; i--)
            {
                array1[i] = s3.Pop();
            }
            Console.Write(String.Join(' ', array1));
            Console.Write(" }\n");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Класс стэк
    /// </summary>
    public class Stack
    {
        /// <summary>
        /// Класс элементов стэка
        /// </summary>
        private class StackItem
        {
            /// <summary>
            /// Основной конструктор, в нем реализуется рекурсия
            /// </summary>
            public StackItem(string[] array)
            {
                Current = array[array.Length - 1];

                if (array.Length > 1)
                {
                    string[] strings = new string[array.Length-1];

                    for (int i = 0; i < strings.Length; i++)
                    {
                        strings[i] = array[i];
                    }

                    Next = new StackItem(strings);
                }
                else
                {
                    Next = null;
                }

            }

            /// <summary>
            /// Пустой конструктор
            /// </summary>
            public StackItem()
            {

            }

            public string Current = null;

            public StackItem Next = null;
        }

        private StackItem stackItem = new StackItem();

        /// <summary>
        /// Основной конструктор
        /// </summary>
        public Stack(params string[] strings)
        {
            foreach (var item in strings)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Stack()
        {

        }

        /// <summary>
        /// Показывает верхний элемент стэка
        /// </summary>
        public string Top => _top;
        private string _top = null;

        /// <summary>
        /// Количество элементов в стэке
        /// </summary>
        public int Size => _size;
        private int _size = 0;

        /// <summary>
        /// Добавляет элемент на верх стэка
        /// </summary>
        /// <param name="item">добавляемый элемент стэка</param>
        public void Add(string item)
        {
            var stack = new StackItem
            {
                Current = item,
                Next = _size != 0 ? stackItem : null,
            };
            _size++;
            _top = stack.Current;
            stackItem = stack;
        }

        /// <summary>
        /// Вытаскивает верхний элемент и удаляет из стэка
        /// </summary>
        /// <returns>верхний элемент стэка</returns>
        /// <exception cref="StackException">Исключение, если стэк пустой</exception>
        public string Pop()
        {
            if (_size == 0) throw new StackException();

            string item = stackItem.Current;

            var stack = new StackItem();

            // Проверка, чтобы небыли затронуты Current и Next 
            if (_size > 1)
            {
                stack = new StackItem
                {
                    Current = stackItem.Next.Current,
                    Next = stackItem.Next.Next,
                };
            }

            stackItem = stack;
            _size--;
            _top = stackItem.Current;

            return item;
        }

        /// <summary>
        /// Статический метод, объединяет любое количество стэков в один единый
        /// </summary>
        /// <param name="stacks">массив стэков</param>
        /// <returns>стэк со всеми значениями</returns>
        public static Stack Concat(params Stack[] stacks)
        {
            var stack = new Stack();

            foreach (var item in stacks)
            {
                var size = item.Size;
                for (int i = 0; i < size; i++)
                {
                    stack.Add(item.Pop());
                }
            }

            return stack;
        }

        // Свое исключение для метода Pop
        public class StackException : Exception
        {
            private string _message = "Стек пустой";
            public override string Message => _message;
            public StackException()
            {

            }
        }
    }

    /// <summary>
    /// Класс расширения для Stack
    /// </summary>
    public static class StackExtensions
    {
        /// <summary>
        /// Соединяет стэки
        /// </summary>
        /// <param name="S">класс Stack</param>
        /// <param name="stack">соединяемый стэк</param>
        public static void Merge(this Stack S, Stack stack)
        {
            var size = stack.Size;
            for (int i = 0; i < size; i++)
            {
                S.Add(stack.Pop());
            }
        }
    }
}