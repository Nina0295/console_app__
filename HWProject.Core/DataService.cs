using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HWProject.Core
{
    public interface IDataService
    {
        Task<string> LoadDataFromApiAsync(string apiUrl);
        void SaveData(string data);
        string ReadData();
        void DeleteData();
        int ValidateData(string input, int totalItems);
        void DisplayTitles();
    }
    public class DataService : IDataService
    {
        private readonly string filePath;

        public DataService(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task<string> LoadDataFromApiAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(apiUrl);
            }
        }

        public void SaveData(string data)
        {
            File.WriteAllText(filePath, data);
        }

        public string ReadData()
        {
            return File.Exists(filePath) ? File.ReadAllText(filePath) : null;
        }

        public void DeleteData()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public int ValidateData(string input, int totalItems)
        {
            if (int.TryParse(input, out int itemNumber))
            {
                if (itemNumber >= 1 && itemNumber <= totalItems)
                {
                    return itemNumber;
                }
                else
                {
                    return -1;
                }
            }

            return -2; 
        }

        public void DisplayTitles()
        {
            var data = ReadData();

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

            var validationResult = ValidateData(input, posts.Length);

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
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
