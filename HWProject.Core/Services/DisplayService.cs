using System;
using System.Text.Json;

using HWProject.Core.Interfaces;

namespace HWProject.Core.Services
{
    public class DisplayService : IDisplayService
    {
        private readonly IFileService fileService;
        private readonly IValidationService validationService;

        public DisplayService(IFileService fileService, IValidationService validationService)
        {
            this.fileService = fileService;
            this.validationService = validationService;
        }

        public void DisplayTitles()
        {
            var data = fileService.ReadData();

            if (string.IsNullOrEmpty(data))
            {
                Console.WriteLine("Файл с данными не найден.");
                return;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var posts = JsonSerializer.Deserialize<Post[]>(data, options);

            if (posts == null || posts.Length == 0)
            {
                Console.WriteLine("Нет данных для отображения.");
                return;
            }

            Console.WriteLine("Введите число для показа заголовка или любую другую клавишу для показа всех заголовков:");
            var input = Console.ReadLine();

            var validationResult = validationService.ValidateData(input, posts.Length);

            if (validationResult > 0)
            {
                Console.WriteLine($"{posts[validationResult - 1].Title}");
            }
            else if (validationResult == -1)
            {
                Console.WriteLine("Неверный номер заголовка.");
            }
            else
            {
                Console.WriteLine("Все заголовки:");
                foreach (var post in posts)
                {
                    Console.WriteLine($"{post.Title}");
                }
            }
        }
    }
}
