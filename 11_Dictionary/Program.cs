namespace ConsoleNET7;

internal class Program
{
    static void Main()
    {
        OtusDictionary dictionary = new();

        try
        {
            // Добавление парочки значений в словарь
            // Данные значения займут индексы с 0 по 19 и 31 
            for (int i = 127; i < 148; i++)
            {
                dictionary.Add(i, $"строка{i}");
            }

            // Проверка на коллизии, со стандартым размером в 32, остаток от 200 будет 8
            // Массив расширится до 128
            // Занятые индексы будут с 0 по 19 и 127, новая строка займет индекс 72 
            dictionary.Add(200, "новая строка200");

            // Проверка метода Get

            // Передадим ключ, которого нету в словаре
            // В ответ получим null
            Console.WriteLine(" Ключ 23213: " + dictionary.Get(23213));

            // Передадим ключ, который есть в словаре
            Console.WriteLine("Ключ 200: " + dictionary.Get(200));

            // Вместо методов Add и Get можно обращаться к массиву через индекс, он равен ключу

            // Поскольку такой ключ уже есть, то произойдет замена значения
            dictionary[200] = "еще одна новая строка";

            // Выдаст новое значение по индексу 200
            Console.WriteLine("Обращение по индексу 200: " + dictionary[200]);

            // Вывод
            for (int i = 0; i < dictionary.Size; i++)
            {
                if (dictionary[i] != null)
                {
                    Console.WriteLine($"Итем: {i} - {dictionary[i]}");
                }
                else
                {
                    Console.WriteLine("Итем: пустой");
                }
            }

            // Исключения

            // Если передать пустую или null строку
            //dictionary.Add(192, null);
            //dictionary.Add(192, "");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
}
