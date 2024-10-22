using System.IO;
using HWProject.Core.Interfaces;

namespace HWProject.Core.Services
{
    public class FileService : IFileService
    {
        private readonly string filePath;

        public FileService(string filePath)
        {
            this.filePath = filePath;
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
    }
}
