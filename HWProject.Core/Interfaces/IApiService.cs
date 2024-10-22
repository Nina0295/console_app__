using System.Threading.Tasks;

namespace HWProject.Core.Interfaces
{
    public interface IApiService
    {
        Task<string> LoadDataFromApiAsync(string apiUrl);
    }
}
