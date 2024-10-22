using System.Threading.Tasks;

namespace HWProject.Core.Interfaces
{
    public interface IValidationService
    {
        int ValidateData(string input, int totalItems);
    }
}
