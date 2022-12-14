=﻿using System.Drawing;

namespace ConsoleNET7;

/// <summary>
/// Переменная, для хранения ключа и значеия
/// </summary>
internal class OtusDictionaryItem
{
    public int Key;

    public string Value;

    internal OtusDictionaryItem(int key, string value)
    {
        this.Key = key;
        this.Value = value;
    }
}

/// <summary>
/// Словарь
/// </summary>
internal class OtusDictionary
{
    
    private OtusDictionaryItem[] Book;

    private int _size = 32;

    public int Size => _size;

    /// <summary>
    /// Индексирование, позволяет заменить методы Add и Get
    /// </summary>
    /// <param name="i"></param>
    /// <returns>Объект OtusDictionaryItem</returns>
    public string this[int i]
    {
        get
        {
            return Get(i);
        }
        set 
        {
            Add(i, value);
        }
    }

    internal OtusDictionary()
    {
        Book = new OtusDictionaryItem[_size];
    }

    /// <summary>
    /// Метод добавления новых данных в словарь
    /// </summary>
    /// <param name="key">ключ</param>
    /// <param name="value">значение</param>
    /// <exception cref="ArgumentNullException">Значение NULL</exception>
    internal void Add(int key, string value)
    {
        if (value is null || value == "")
        {
            throw new Exception("В словарь было переданна запись с null или пустой строкой");
        }

        OtusDictionaryItem item = new(key, value);

        int index = Hash(key, _size);

        // Проверка коллизии
        if (Book[index] is null)
        {
            Book[index] = item;
        }
        // В случае совпадения ключа, перезаписывает значение
        else if (Book[index].Key == item.Key)
        {
            Book[index].Value = value;
        }
        // Уходит в метод расширения массива
        else
        {
            ReSize(key, value);
        }
    }

    /// <summary>
    /// Метод нахождения объекта по ключу
    /// </summary>
    /// <param name="key">ключ</param>
    /// <returns>Значение</returns>
    internal string Get(int key)
    {
        int index = Hash(key, _size);

        if (Book[index] is null)
        {
            return null;
        }
        else
        {
            return Book[index].Value;
        }
    }

    /// <summary>
    /// Метод расширающий массив в два раза, в случаи нахождений коллизии
    /// </summary>
    /// <param name="key">ключ</param>
    /// <param name="value">значение</param>
    private void ReSize(int key, string value)
    {
        OtusDictionaryItem[] tempBook = new OtusDictionaryItem[_size * 2];

        int tempSize = tempBook.Length;

        foreach (var dictionaryItem in Book)
        {
            if (dictionaryItem is not null)
            {
                int itemIndex = Hash(dictionaryItem.Key, tempSize);

                tempBook[itemIndex] = dictionaryItem;
            }
        }

        Book = tempBook;
        _size = tempSize;

        // Метод добавления внесен сюда, чтобы алгоритм увеличивал массив до тех пор, пока индекс не станет уникальным
        Add(key, value);
    }

    /// <summary>
    /// Метод индексирования по ключу
    /// </summary>
    /// <param name="key">ключ</param>
    /// <param name="size">размер славаря</param>
    /// <returns>индекс</returns>
    private int Hash(int key, int size)
    {
        return (key & 0x7ffffff) % size;
    }
}