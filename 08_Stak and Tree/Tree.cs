namespace OtusHomeWork_08_Stack_and_Tree;

/// <summary>
/// Класс бинарного дерева, содержит ноды древа и методы для работы с ними
/// </summary>
internal class Tree
{
    /// <summary>
    /// Нода, дерева, содержит имя и зарплату сотрудника
    /// Так же имеет ссылки на соседние ноды
    /// </summary>
    internal class Node
    {
        public int? Money { get; set; }
        public string? Name { get; set; }

        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    /// <summary>
    /// Процедура обхода дерева, рекурсивная.
    /// Тип обхода: inorder
    /// </summary>
    /// <param name="tree">дерево</param>
    /// <exception cref="Exception">ошибка, переданно пустое дерево</exception>
    internal static void Traverse(Node tree)
    {
        if (tree == null)
        {
            throw new Exception("1");
        }

        if (tree.Left != null)
        {
            Traverse(tree.Left);
        }

        Console.WriteLine($"{tree.Name} {tree.Money}");

        if (tree.Right != null)
        {
            Traverse(tree.Right);
        }
    }

    /// <summary>
    /// Процедура добавления ноды в дерево, рекурсивная
    /// </summary>
    /// <param name="tree">дерево</param>
    /// <param name="name">имя сотрудника</param>
    /// <param name="money">зарплата сотрудника</param>
    internal static void AddNode(Node tree, string name, int money)
    {
        if (tree.Money > money)
        {
            if (tree.Left == null)
            {
                tree.Left = new Node()
                {
                    Name = name,
                    Money = money
                };
            }
            else
            {
                AddNode(tree.Left, name, money);
            }
        }
        else if (tree.Money <= money)
        {
            if (tree.Right == null)
            {
                tree.Right = new Node()
                {
                    Name = name,
                    Money = money
                };
            }
            else
            {
                AddNode(tree.Right, name, money);
            }

        }
    }

    /// <summary>
    /// Процедура поиска ноды по зарплате сотрудника, рекурсивная
    /// </summary>
    /// <param name="tree">дерево</param>
    /// <param name="money">зарплата сотрудника</param>
    internal static void Find(Node tree, int money)
    {
        if (tree.Money == money)
        {
            Console.WriteLine($"Найдено: {tree.Name} - {tree.Money}");
        }
        else if (tree.Money > money)
        {
            if (tree.Left is null)
            {
                Console.WriteLine("Не найдено");
            }
            else
            {
                Find(tree.Left, money);
            }
        }
        else if (tree.Money < money)
        {
            if (tree.Right is null)
            {
                Console.WriteLine("Не найдено");
            }
            else
            {
                Find(tree.Right, money);
            }
        }
    }
}
}