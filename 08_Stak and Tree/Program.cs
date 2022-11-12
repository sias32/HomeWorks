namespace OtusHomeWork_08_Stack_and_Tree;

internal static class Program
{
    internal static void Main()
    {
        // Основной цикл
        // В нем есть подциклы
        // 1 - ввод переменных и создание дерева
        //   1.1 - ввод и проверка
        // 2 - ввод переменных для поиска и вывод
        while (true)
        {
            Tree.Node? tree = null;
            bool exit = true;

            Console.WriteLine("Программа по созданию списка сотрудников и поиска по зарплате\n" +
                "Введите \"!\" - чтобы выйти\n" +
                "Нажмите \"Enter\" - чтобы завершить\n");

            // Цикл 1
            do
            {
                string name;
                int money = 0;

                Console.Write("Введите имя: ");
                name = Console.ReadLine()!;

                if (name == "!")
                {
                    exit = false;
                    break;
                }
                else if (name == "")
                {
                    Console.WriteLine();
                    break;
                }

                // Цикл 1.1
                do
                {
                    Console.Write("Введите его зарплату: ");
                    bool result = int.TryParse(Console.ReadLine(), out money);
                    Console.WriteLine();

                    if (result) break;
                    else Console.WriteLine("Неверно введена зарплата");

                } while (true);

                if (tree == null)
                {
                    tree = new()
                    {
                        Name = name,
                        Money = money,
                    };
                }
                else
                {
                    Tree.AddNode(tree, name!, money);
                }

            } while (true);

            // Проверка, хотел ли пользователь завершить программу
            if (!exit) break;
            Console.Clear();
            Console.WriteLine("Список людей и их зарплата");

            // Проверка пустого древа
            try
            {
                Tree.Traverse(tree!);
            }
            catch (Exception e)
            {
                if (e.Message == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Вы ничего не ввели");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Можно найти сотрудника по его зарплате\n" +
                "Введите \"!\" - чтобы выйти\n" +
                "Нажмите \"Enter\" - чтобы завершить\n");

            // Цикл 2
            do
            {
                int money = 0;
                string? str = null;

                Console.Write("Ввод: ");
                str = Console.ReadLine()!;
                if (str == "!")
                {
                    exit = false;
                    break;
                }
                else if (str == "") break;

                bool result = int.TryParse(str, out money);
                if (!result)
                {
                    Console.WriteLine("Неверно введена зарплата");
                    continue;
                }

                Console.WriteLine();

                Tree.Find(tree!, money);

            } while (true);

            if (!exit) break;

            Console.Clear();
        }
    }
}