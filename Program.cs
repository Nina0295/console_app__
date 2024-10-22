using HWProject.Core.Services;
using HWProject.Core.Interfaces;
using System.Text;

namespace HWProject.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string filePath = @"C:\Users\v-ninabelova\data.json";
            string apiUrl = "https://jsonplaceholder.typicode.com/posts";
            IApiService apiService = new ApiService();
            IFileService fileService = new FileService(filePath);
            IValidationService validationService = new ValidationService();
            IDisplayService displayService = new DisplayService(fileService, validationService);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Загрузить данные");
                Console.WriteLine("2. Показать данные");
                Console.WriteLine("3. Удалить данные");
                Console.WriteLine("Введите 'q' для выхода");
                Console.WriteLine("Выберите действие (1, 2, 3):");

                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                        var data = await apiService.LoadDataFromApiAsync(apiUrl);
                        fileService.SaveData(data);
                        Console.WriteLine("Данные загружены и сохранены.");
                        break;
                    case "2":
                        displayService.DisplayTitles();
                        break;
                    case "3":
                        fileService.DeleteData();
                        Console.WriteLine("Файл с данными удален.");
                        break;
                    case "q":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            }
        }
    }
}
