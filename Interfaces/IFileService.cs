using System.Threading.Tasks;

namespace HWProject.Core.Interfaces
{
    public interface IFileService
    {
        void SaveData(string data);
        string ReadData();
        void DeleteData();
    }
}
