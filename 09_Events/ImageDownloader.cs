using System.Net;

namespace ConsoleApp_NET6;

internal class ImageDownloader
{
    public void Download(string url, string file)
    {
        // Для отображения имени сайта
        Uri uri= new(url);
        string fileName = file.Split('/')[file.Split('/').Length - 1];

        Console.WriteLine($"Скачиваю с сайта: {uri.Host}\n");

        Task taskStatus;
        using (WebClient webClient = new())
        {
            taskStatus = webClient.DownloadFileTaskAsync(url, file);
        }

        while (true)
        {
            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.A)
            {
                Console.WriteLine();
                break;
            }
            else
            {
                if (taskStatus.IsCompleted == Task.CompletedTask.IsCompleted)
                {
                    Console.WriteLine("Скачалось");
                }
                else
                {
                    Console.WriteLine("Еще не скачалось");
                }
            }
        }
        Console.WriteLine($"Успешно сохранил как: {fileName}");
    }
}