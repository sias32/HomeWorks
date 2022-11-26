namespace ConsoleNET7;

internal class Program
{
    static void Main()
    {
        string root = @"C:\Otus";

        if (!Directory.Exists(root))
        {
            Directory.CreateDirectory(root);
        }

        for (int i = 1; i <= 2; i++)
        {
            string dirName = $@"TestDir{i}";
            string dirPath = $@"{root}\{dirName}";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            for (int j = 1; j <= 10; j++)
            {
                string fileName = $@"File{j}.txt";
                string filePath = $@"{root}\{dirName}\{fileName}";

                if (!File.Exists(filePath))
                {
                    FileCreater(filePath);

                    FileWriteInfo(filePath, fileName);
                }

                if (File.Exists(filePath))
                {
                    FileWriteDateTime(filePath);

                    FileReadInfo(filePath, dirPath);
                }
            }

        }
    }

    /// <summary>
    /// Создает файл (using)
    /// </summary>
    /// <param name="path">Путь файла</param>
    public static void FileCreater(string path)
    {
        using (FileStream fileStream = new(path, FileMode.Create))
            fileStream.Close();

    }

    /// <summary>
    /// Записывает в файл мета данные
    /// </summary>
    /// <param name="path">Путь файла</param>
    /// <param name="name">Имя файла</param>
    public static void FileWriteInfo(string path, string name)
    {
        using (StreamWriter sWriter = new(path, false, Encoding.UTF8))
            sWriter.WriteLine(name);
    }

    /// <summary>
    /// Добавляет в файл мета даные - время
    /// </summary>
    /// <param name="path">Путь файла</param>
    public static void FileWriteDateTime(string path)
    {
        using (StreamWriter sWriter = new(path, true, Encoding.UTF8))
            sWriter.WriteLine(DateTime.Now.ToString());

    }

    /// <summary>
    /// Считывает мета данные у файла, если их нет, вызывает FileWriteInfo
    /// </summary>
    /// <param name="path">Путь файла</param>
    /// <param name="dir">Каталог файла</param>
    public static void FileReadInfo(string path, string dir)
    {
        using (StreamReader sReader = new(path, Encoding.UTF8))
        {
            string strFile = sReader.ReadToEnd()!;

            Console.WriteLine($"{dir}: {strFile}");
        }
    }
}