using HWProject.Core.Interfaces;

namespace HWProject.Core.Services
{
    public class ValidationService : IValidationService
    {
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
    }
}

