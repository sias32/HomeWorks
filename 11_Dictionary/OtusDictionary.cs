namespace Dictionary;

/// <summary>
/// Переменная, для хранения ключа и значеия
/// </summary>
internal class OtusDictionaryItem
{
    public int key;

    public string value;

    internal OtusDictionaryItem(int key, string value)
    {
        this.key = key;
        this.value = value;
    }
}

/// <summary>
/// Словарь
/// </summary>
internal class OtusDictionary
{
    
    private OtusDictionaryItem[] Book;

    private int _size;

    public int length => _size;

    /// <summary>
    /// Индексирование, позволяет заменить методы Add и Get
    /// </summary>
    /// <param name="i"></param>
    /// <returns>Объект OtusDictionaryItem</returns>
    public OtusDictionaryItem this[int i]
    {
        get
        {
            return Get(i);
        }
        set 
        {
            Add(value.key, value.value);
        }
    }

    internal OtusDictionary()
    {
        Book = new OtusDictionaryItem[32];
        _size = Book.Length;
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
                int itemIndex = dictionaryItem.key % tempSize;

                tempBook[itemIndex] = dictionaryItem;
            }
        }

        Book = tempBook;
        _size = tempSize;

        // Метод добавления вынесен сюда, чтобы алгоритм увеличивал массив до тех пор, пока индекс не станет уникальным
        Add(key, value);
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

        int index = key % _size;

        // Проверка коллизии
        if (Book[index] is null)
        {
            Book[index] = item;
        }
        // В случае совпадения ключа, перезаписывает значение
        else if (Book[index].key == item.key)
        {
            Book[index].value = value;
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
    internal OtusDictionaryItem Get(int key)
    {
        int index = key % _size;

        if (Book[index] is null)
        {
            return null;
        }
        else
        {
            return Book[index];
        }
    }
}