namespace ConsoleApp_NET6;

internal class Program
{
    public static event Action<int> ImageNews;

    static void Main(string[] args)
    {
        // Добавление обработчика события
        ImageNews += ImageHandler;

        string url = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
        //Так файл скачивается в корень проекта
        string file = "../../../bigimage.jpg";

        ImageDownloader imageDownloader = new ImageDownloader();

        ImageNews.Invoke(1);
        imageDownloader.Download(url, file);
        ImageNews.Invoke(0);
    }

    /// <summary>
    /// Отлавливает события Event
    /// </summary>
    /// <param name="status">статус скачивания (1;0)</param>
    private static void ImageHandler(int status)
    {
        if (status == 1)
        {
            Console.WriteLine("Скачивание файла началось");
        }

        if (status == 0)
        {
            Console.WriteLine("Скачивание файла закончилось");
        }
    }
}