using HWProject.Core.Interfaces;

namespace HWProject.Core.Services
{
    public class ApiService : IApiService
    {
        public async Task<string> LoadDataFromApiAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(apiUrl);
            }
        }
    }
}
